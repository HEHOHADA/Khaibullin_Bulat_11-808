using System;

namespace VKMVC.Service
{
    public class EmailService : IMessageSender
    {
        public void Send()
        {
            Console.WriteLine("Check Email");
        }
    }
}