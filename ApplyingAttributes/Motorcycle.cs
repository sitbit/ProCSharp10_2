using AttributedCarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
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
