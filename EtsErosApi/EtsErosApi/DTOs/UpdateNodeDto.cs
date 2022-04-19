using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EtsErosApi.DTOs
{
    public class UpdateNodeDto
    {
        [Required]
        [JsonPropertyName("current-id")]
        public int CurrentId { get; set; }
    }
}
