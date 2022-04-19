using System.ComponentModel.DataAnnotations;

namespace EtsErosApi.DTOs
{
    public class AddNodeDto
    {
        [Required]
        public int Parent { get; set; }
        [Required]
        public string Label { get; set; }
    }
}
