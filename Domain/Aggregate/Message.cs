using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregate
{
    [Table("Message")]
    public class Message
    {
        public Message(string body, string fromUserId, string toUserId, DateTime createdDate, int messageStatus)
        {
            Body = body;
            FromUserId = fromUserId;
            ToUserId = toUserId;
            CreatedDate = createdDate;
            MessageStatus = messageStatus;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; private set; }

        public string Body { get; private set; }
        public string FromUserId { get; private set; }
        public string ToUserId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int MessageStatus { get; set; } //0 init, 1 UserSent, 2 ServerReceived, 3 EndUserReceived
    }

    public enum MessageStatus
    {
        INIT = 0,
        SERVER_RECIEVED = 1,
        USER_RECEIVED = 2,
        USER_READ_MESSAGE = 3
    }
}