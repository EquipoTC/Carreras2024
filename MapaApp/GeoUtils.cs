using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    internal class GeoUtils
    {
        public static double Calculate_Distance(PointLatLng point1, PointLatLng point2)
        {
            return GMapProviders.EmptyProvider.Projection.GetDistance(point1, point2); // KM
        }
    }
}
