using Data.Domain.Entities;

namespace CreatingModels
{
    public class TagCreatingModel : CreatingModel<Tag>

    {
    public string Label { get; set; }
    }
}
