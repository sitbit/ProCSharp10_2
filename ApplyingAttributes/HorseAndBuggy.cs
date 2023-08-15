using AttributedCarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    [XmlRoot(Namespace = "https://www.MyCompany.ca"), Obsolete("Use another vehicle!")]
    [VehicleDescription("The old grey mare, she ain't what she used to be...")]
    internal class HorseAndBuggy
    {
    }
}
