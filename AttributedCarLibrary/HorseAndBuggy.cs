using System.Xml.Serialization;

namespace AttributedCarLibrary
{
    [XmlRoot(Namespace = "https://www.MyCompany.ca"), Obsolete("Use another vehicle!")]
    [VehicleDescription("The old grey mare, she ain't what she used to be...")]
    internal class HorseAndBuggy
    {
    }
}
