using System.Text.Json;

namespace Shopping_Web.Models
{
    public class MiddleResult
    {
        public Dictionary<string, JsonElement> records { get; set; }

        public Dictionary<string, JsonElement> result { get; set; }

        public string success { get; set; }
    }
}
