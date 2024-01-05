using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CommentId { get; set; }
        public int PostTopicId { get; set; }
        public string PostContent { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
