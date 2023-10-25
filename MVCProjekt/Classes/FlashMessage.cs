namespace MVCProjekt.Classes
{

    //Třída, která vytvoří základ pro flashmessageType -> Související část je na HtmlHelperExtensions

    public enum FlashMessageType
    {
        Info,
        Success,
        Warning,
        Danger
    }
    public class FlashMessage
    {
        public string Message { get; set; }
        public FlashMessageType Type { get; set; }

        public FlashMessage(string message, FlashMessageType type)
        {
            Message = message;
            Type = type;
        } 
    }
}
