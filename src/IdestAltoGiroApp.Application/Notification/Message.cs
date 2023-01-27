namespace IdestAlgotGiroApp.Application.Notification;

    public class Message
    {
        public Message(string property, string detail)
        {
            Property = property;
            Detail = detail;
        }

        public string Property { get; set; }
        public string Detail{ get; set; }

    }
