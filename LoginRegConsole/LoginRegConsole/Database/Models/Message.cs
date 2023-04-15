using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database.Models
{
    public class Message
    {
        public string MessageBody { get; set; }
        public DateTime SendTime { get; set; } 
        public User SendingUser { get; set; }   
        public User ReceivingUser { get; set; }

        public Message(string subject, User sendingUser, User receivingUser)
        {
            MessageBody = subject;
            SendTime = DateTime.Now;
            SendingUser = sendingUser;
            ReceivingUser = receivingUser;
        }



        
    }
}
