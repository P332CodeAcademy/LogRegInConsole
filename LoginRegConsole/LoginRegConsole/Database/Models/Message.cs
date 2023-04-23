using LoginRegConsole.Database.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database.Models
{
    public class Message:BaseEntity
    {
        public string MessageBody { get; set; }
        public DateTime SendTime { get; set; } 
        public User SendingUser { get; set; }   
        public User ReceivingUser { get; set; }

        public Message(string subject, User sendingUser, User receivingUser)
        {
			Id = ++BaseEntity._idCounter;
			MessageBody = subject;
            SendTime = DateTime.Now;
            SendingUser = sendingUser;
            ReceivingUser = receivingUser;
        }



        
    }
}
