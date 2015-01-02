using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Models
{
    public class Role
    {
        private IList<User> _users { get; set; }

        protected Role()
        {
            this.Id = Guid.NewGuid();
            this._users = new List<User>();
        }
        public Role(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this._users = new List<User>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<User> Users
        {
            get { return _users; }
            protected set { _users = new List<User>(value); }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
