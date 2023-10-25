using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProjekt.Classes;

namespace MVCProjekt.Extensions
{
    public static class HtmlHelperExtensions
    {

        //Render FlashMessage na stránce
        public static IHtmlContent RenderFlashMessages(this IHtmlHelper helper)
        {
            var messageList = helper.ViewContext.TempData
                .DeserializeToObject<List<FlashMessage>>("Messages");
            var html = new HtmlContentBuilder();

            foreach (var msg in messageList)
            {
                var container = new TagBuilder("div");
                container.AddCssClass($"alert alert-dismissible fade show alert-{msg.Type.ToString().ToLower()}"); //použijeme název flagu jakožto css třídu
                container.InnerHtml.SetContent(msg.Message);

                //tlačítko pro zavření zprávy
                var dismissButton = new TagBuilder("button");
                dismissButton.AddCssClass("btn-close");
                dismissButton.Attributes.Add("type", "button");
                dismissButton.Attributes.Add("data-bs-dismiss", "alert");
                container.InnerHtml.AppendHtml(dismissButton);

                html.AppendHtml(container);
            }
            return html;
        }
    }
}
