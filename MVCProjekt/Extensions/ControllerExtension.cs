using Microsoft.AspNetCore.Mvc;
using MVCProjekt.Classes;

namespace MVCProjekt.Extensions
{
    public static class ControllerExtension
    {

        public static void AddFlashMessage(this Controller controller, FlashMessage message)
        {
            //Stejně jako u rozšíření pro HtmlHelper, také zde můžeme pracovat i s prázdným seznamem
            var list = controller.TempData.DeserializeToObject<List<FlashMessage>>("Messages");

            list.Add(message);

            //uložíme rozšířený seznam zpráv zpátky do formutu json a kolekce TempData
            controller.TempData.SerializeObject(list, "Messages");
        }

        public static void AddFlashMessage(this Controller controller, string message, FlashMessageType messagetype)
        {
            controller.AddFlashMessage(message, messagetype);
        }

        public static void AddDebugMessage(this Controller controller, Exception ex)
        {
            string message = ex.Message;
            if (ex.GetBaseException().Message != message)
                message += Environment.NewLine + ex.GetBaseException().Message;

            AddFlashMessage(controller, new FlashMessage(message, FlashMessageType.Danger));
        }
    }
}
