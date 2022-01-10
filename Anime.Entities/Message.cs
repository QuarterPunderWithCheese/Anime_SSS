using System;

namespace DomainModel.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public User FromUser { get; set; }
        public User ToUser { get; set; }
    }
}