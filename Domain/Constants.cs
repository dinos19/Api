namespace Domain
{
    public class Constants
    {
        public static string RabbiqMqApiExchange = "RabbiqMqApiExchange"; //Container name
        public static string RabbiqMqApiRoutingKey = "RabbiqMqApiRoutingKey"; //who is sending it, system(action) or user(message)
        public static string RabbiqMqApiQueueName = "RabbiqMqApiQueueName";  //key to determine who is going to read it
    }
}