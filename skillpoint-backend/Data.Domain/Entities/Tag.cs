using System;
using System.Collections.Generic;

namespace Data.Domain.Entities
{
    public class Tag
    {
        public Guid Id { get; private set; }

        private string _label;

        public string Label
        {
            get => this._label;
            set => CheckLabel(value);
        }

        public List<User> Users { get; private set; }

        public bool Verified { get; private set; }

        private Tag()
        {
        }

        public static Tag Create(string label, User user)
        {
            var instance = new Tag() {Id = Guid.NewGuid(), Users = new List<User>()};
            instance.Update(label, false, user);
            return instance;
        }

        public void Update(string label, bool verified, User user)
        {
            this.Label = label;
            this.Verified = verified;
            this.Users.Add(user);
        }

        private void CheckLabel(string label)
        {
            if (label == null)
            {
                throw new Exception("Invalid label!(No value specified!)");
            }
            else
            {
                this._label = label;
            }
        }
    }
}