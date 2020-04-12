using System;

namespace VKMVC.Service
{
    public class SMSService : IMessageSender
    {
        public void Send()
        {
            Console.WriteLine("Check phone");
        }
    }
}