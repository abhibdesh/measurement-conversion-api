using System.ComponentModel.DataAnnotations;

namespace UnitsConversionModule.Models.Requests
{
    public class ConversionRequest
    {
        [Required]
        public string Category { get; set; } = string.Empty;


        [Required]
        public string FromUnit { get; set; } = string.Empty;


        [Required]
        public string ToUnit { get; set; } = string.Empty;

        [Required]
        [Range(double.MinValue, double.MaxValue)]
        public double Value { get; set; }
    }
}
