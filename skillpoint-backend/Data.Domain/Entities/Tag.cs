using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CreatingModels;

namespace Data.Domain.Entities
{
    public class Tag
    {
        private string _label;
        
        [Key]
        public string Label
        {
            get => _label;
            private set => CheckLabel(value);
        }

        public List<UserTag> UsersList { get; private set; }

        public bool Verified { get; private set; }

        private Tag()
        {
        }

        public static Tag Create(TagCreatingModel tagModel)
        {
            var instance = new Tag();
            instance.Update(tagModel.Label, false);
            return instance;
        }

        public void Update(string label, bool verified)
        {
            Label = label;
            Verified = verified;
        }

        private void CheckLabel(string label)
        {
            if (label == null)
            {
                throw new Exception("Invalid label!(No value specified!)");
            }
            _label = label;
        }
    }
}