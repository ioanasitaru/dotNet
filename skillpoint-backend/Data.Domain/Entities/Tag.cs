using System;

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

        public bool Verified { get; private set; }

        private Tag()
        {
        }

        public static Tag Create(string label)
        {
            var instance = new Tag() {Id = Guid.NewGuid()};
            instance.Update(label, false);
            return instance;
        }

        public void Update(string label, bool verified)
        {
            this.Label = label;
            this.Verified = verified;
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