using CreatingModels;
using Data.Domain.Entities;

namespace DTOs
{
    public class TagDTO : TagCreatingModel
    {
        public TagDTO(UserTag ut) : this(ut.Tag) { }

        public TagDTO(EventTag et) : this(et.Tag) { }

        public TagDTO(string label, bool verified) : base(label, verified) { }

        public TagDTO(Tag t) : this(t.Label, t.Verified) { }
    }
}