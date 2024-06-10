using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace FormulaOneTech.Services.Circuit
{
    public class ImageMappingService
    {
        private readonly Dictionary<string, Dictionary<string, string>> _mapping = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "albert_park", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Australia_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Australia.png"}
                }
            },
            {
                "americas", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/USA_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/USA.png"}
                }
            },
            {
                "bahrain", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Bahrain_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Bahrain.png"}
                }
            },
            {
                "baku", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Baku_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Azerbaijan.png"}
                }
            },
            {
                "catalunya", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Spain_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Spain.png"}
                }
            },
            {
                "silverstone", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Great_Britain_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Great_Britain.png"}
                }
            },
            {
                "hungaroring", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Hungary_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Hungar.png"}
                }
            },
            {
                "imola", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Emilia_Romagna_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Emilia_Romagna.png"}
                }
            },
            {
                "interlagos", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Brazil_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Brazil.png"}
                }
            },
            {
                "jeddah", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Saudi_Arabia_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Saudi_Arabia.png"}
                }
            },
            {
                "losail", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Qatar_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Qatar.png"}
                }
            },
            {
                "marina_bay", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Singapore_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Singapore.png"}
                }
            },
            {
                "miami", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Miami_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Miami.png"}
                }
            },
            {
                "monaco", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Monoco_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Monte_Carlo.png"}
                }
            },
            {
                "monza", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Italy_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Italy.png"}
                }
            },
            {
                "red_bull_ring", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Austria_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Austria.png"}
                }
            },
            {
                "rodriguez", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Mexico_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Mexico.png"}
                }
            },
            {
                "shanghai", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/China_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/China.png"}
                }
            },
            {
                "spa", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Belgium_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Belgium.png"}
                }
            },
            {
                "suzuka", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Japan_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Japan.png"}
                }
            },
            {
                "vegas", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Las_Vegas_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Las_Vegas.png"}
                }
            },
            {
                "villeneuve", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Canada_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Canada.png"}
                }
            },
            {
                "yas_marina", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Abu_Dhabi_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Abu_Dhab.png"}
                }
            },
            {
                "zandvoort", new Dictionary<string, string>
                {
                    { "detailed", "/static/Circuits/TrackDetail/Netherlands_Circuit.png" },
                    { "mini" , "/static/Circuits/Minimap/Netherlands.png"}
                }
            }
        };

        /// <summary>
        /// Gets path to circuit image
        /// </summary>
        /// <param name="circuitId">grabbed from ergast service api</param>
        /// <param name="imageType">Returns either mini or detailed map image</param>
        /// <returns></returns>
        public string GetImageForCircuit(string circuitId, string imageType)
        {
            if (_mapping.TryGetValue(circuitId, out var circuitMapping))
            {
                if (circuitMapping.TryGetValue(imageType, out string imagePath))
                {
                    return imagePath;
                }
            }
            return null;
        }

    }
}
