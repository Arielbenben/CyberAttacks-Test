using DefencesCyberTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DefencesCyberTest.Utils
{
    internal static class JsonUtils
    {
        public static T? ReadFromJson<T>(string filePath, JsonSerializerOptions options = null)
        {
            try
            {
                options ??= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                T? data = JsonSerializer.Deserialize<T>(
                    File.OpenRead(filePath),
                    options
                );
                return data;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public static List<DefenceModel>? GetAllDefences() =>
            ReadFromJson<List<DefenceModel>>("../../../defenceStrategiesBalanced.json");

        public static List<ThreatModel>? GetAllThreats() =>
            ReadFromJson<List<ThreatModel>>("../../../threats.json");

    }
}
