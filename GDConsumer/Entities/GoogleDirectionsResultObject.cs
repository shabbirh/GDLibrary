using System.Collections.Generic;

namespace GDConsumer.Entities
{
    public class GoogleDirectionsResultObject
    {
        public List<Route> routes { get; set; }
        public string status { get; set; }
    }
}