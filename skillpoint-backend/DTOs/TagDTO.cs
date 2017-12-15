using Data.Domain.Entities;

namespace DTOs
{
    public class TagDTO
    {
        public TagDTO(UserTag ut)
        {
            Label = ut.TagLabel;
            Verified = ut.Tag.Verified;
        }

        public string Label { get; set; }
        public bool Verified { get; set; }
    }
}