using System;

namespace RoomBooking.Core.Models
{
    public class Book
    {
        public Book(string name, string email, DateTime startTime, DateTime endTime)
        {
            this.Id = new Guid();
            this.Name = name;
            this.Email = email;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        protected Book() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
    }
}
