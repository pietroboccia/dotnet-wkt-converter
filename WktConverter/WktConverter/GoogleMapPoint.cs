using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WktConverter;

public class GoogleMapPoint
{
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }
    [JsonPropertyName("lng")]
    public double Longitude { get; set; }
}
