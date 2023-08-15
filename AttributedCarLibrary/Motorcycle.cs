using System.Text.Json.Serialization;

namespace AttributedCarLibrary
{
    [VehicleDescription(Description = "My rockin' Harley!")]
    internal class Motorcycle
    {
        [JsonIgnore]
#pragma warning disable CS0649 // Field 'Motorcycle._weightOfCurrentPassengers' is never assigned to, and will always have its default value 0
        public float _weightOfCurrentPassengers;
        //  The following fields can still be serialized:
        public bool _hasRadioSystem;
        public bool _hasHeadSet;
        public bool _hasSissyBar;
    }
}
