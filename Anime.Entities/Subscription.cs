using System;

namespace DomainModel.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}