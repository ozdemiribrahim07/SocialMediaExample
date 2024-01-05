using Core.Entities;

namespace Entities.Concrete
{
    public class PostTopic : IEntity
    {
        public int Id { get; set; }
        public string TopicName { get; set; }
    }
}
