using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;

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
