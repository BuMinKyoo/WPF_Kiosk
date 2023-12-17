namespace WPF_Kiosk
{
    public class CustomMessage
    {
        public string EventName { get; set; }
        public object Message { get; set; }

        public CustomMessage(string eventName, object message)
        {
            EventName = eventName;
            Message = message;
        }
    }
}
