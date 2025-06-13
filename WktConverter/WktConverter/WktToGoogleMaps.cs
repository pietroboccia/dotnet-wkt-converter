using NetTopologySuite.IO;
using NetTopologySuite.Geometries;

namespace WktConverter;

public static class WktToGoogleMaps
{
    public static List<List<GoogleMapPoint>> ParseWktPolygons(string wkt)
    {
        var reader = new WKTReader();
        var geometry = reader.Read(wkt);

        var result = new List<List<GoogleMapPoint>>();

        if (geometry is Polygon polygon)
        {
            result.Add(ExtractCoordinates(polygon.ExteriorRing));
        }
        else if (geometry is MultiPolygon multiPolygon)
        {
            for (int i = 0; i < multiPolygon.NumGeometries; i++)
            {
                var poly = (Polygon)multiPolygon.GetGeometryN(i);
                result.Add(ExtractCoordinates(poly.ExteriorRing));
            }
        }
        else
        {
            throw new NotSupportedException("Solo POLYGON e MULTIPOLYGON sono supportati in questo esempio.");
        }

        return result;
    }

    private static List<GoogleMapPoint> ExtractCoordinates(LineString ring)
    {
        var coords = new List<GoogleMapPoint>();
        foreach (var coord in ring.Coordinates)
        {
            coords.Add(new GoogleMapPoint { Latitude = coord.Y, Longitude = coord.X });
        }
        return coords;
    }
}