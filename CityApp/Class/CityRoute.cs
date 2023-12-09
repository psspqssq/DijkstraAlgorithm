using System;
using System.Collections.Generic;

namespace CityApp.Class
{
    public class CityRoute
    {
       public int Id { get; set; }
       public string From { get; set; }
       public string To { get; set; }
       public DateTime StartTime { get; set; }
       public DateTime EndTime { get; set; }
       public ICollection<XYCoordinate> movementArray { get; set; }
       public float approximateTravelTime { get; set; }

    }
}
