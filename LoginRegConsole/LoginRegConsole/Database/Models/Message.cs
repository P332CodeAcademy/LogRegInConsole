using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database.Models
{
    public class Message
    {
        public Message(string subject, string description, User sendingUser, User receivingUser)
        {
            Subject = subject;
            Description = description;
            SendTime = DateTime.Now;
            SendingUser = sendingUser;
            ReceivingUser = receivingUser;
            IsOpen= false;
        }

        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime SendTime { get; set; } 
        public User SendingUser { get; set; }   
        public User ReceivingUser { get; set; }
        public bool IsOpen { get; set; }


        
    }
}
