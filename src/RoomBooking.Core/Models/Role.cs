using System.Collections.Generic;

namespace RoomBooking.Core.Models
{
    public class Role
    {
        private IList<User> _users { get; set; }

        public Role(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
        public IEnumerable<User> Users
        {
            get { return _users; }
            protected set { _users = new List<User>(value); }
        }
    }
}
