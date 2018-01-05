using System;

namespace Data.Domain.Entities
{
    public class UserTag
    {

        private UserTag() { }

        public UserTag(string userId, User user, string label, Tag tag)
        {
            UserId = userId;
            User = user;
            TagLabel = label;
            Tag = tag;
        }

        public string UserId { get; private set; }
        public User User { get; set; }

        public string TagLabel { get; private set; }
        public Tag Tag { get; set; }
    }
}
