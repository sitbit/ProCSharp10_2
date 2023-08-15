namespace AttributedCarLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; } = string.Empty;

        public VehicleDescriptionAttribute() { }
        public VehicleDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}