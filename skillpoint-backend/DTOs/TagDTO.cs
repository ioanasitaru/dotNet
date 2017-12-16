using Data.Domain.Entities;

namespace DTOs
{
    public class TagDTO : DTO<Tag>
    {
        public TagDTO(UserTag ut) : this(ut.Tag) { }

        public TagDTO(string label, bool verified)
        {
            Label = label;
            Verified = verified;
        }

        public TagDTO(Tag t) : this(t.Label, t.Verified) { }

        public string Label { get; set; }
        public bool Verified { get; set; }
    }
}