namespace BeadBE.Application.Common.Responses
{
    public readonly struct ValidationError
    {
        public string Property { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        public ValidationError(string property, string description)
        {
            Property = property;
            Description = description;
        }
    }
}
