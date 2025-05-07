using System.Text.Json.Serialization;

namespace ItauChalenge.Models
{
    public class Transaction
    {
        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }

        [JsonPropertyName("dataHora")]
        public DateTime Data_Hour { get; set; }
    }
}
