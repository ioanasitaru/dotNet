namespace CreatingModels
{
    public class TagCreatingModel

    {
        public TagCreatingModel(string label, bool verified)
        {
            Label = label;
            Verified = verified;
        }

        public string Label { get; set; }
        public bool Verified { get; set; }
    }
}
