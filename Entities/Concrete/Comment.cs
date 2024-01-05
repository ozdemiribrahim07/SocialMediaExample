using Core.Entities;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string TextComment { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
