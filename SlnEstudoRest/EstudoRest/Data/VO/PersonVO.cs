using EstudoRest.HyperMedia;
using EstudoRest.HyperMedia.Abstract;
using System.Text.Json.Serialization;

namespace EstudoRest.Data.VO
{
    public class PersonVO : ISupportsHyperMedia

    {
        [JsonPropertyName("Code")]
        public long Id { get; set; }
        [JsonPropertyName("Primeiro_Nome")]
        public string FirstName { get; set; }
        [JsonPropertyName("Ultimo_Nome")]
        public string LastName { get; set; }
        [JsonIgnore]
        public string Address { get; set; }
        [JsonPropertyName("Sexo")]
        public string Gender { get; set; }

        public bool Enabled { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
