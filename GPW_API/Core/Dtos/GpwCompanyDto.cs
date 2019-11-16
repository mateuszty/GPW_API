using System.ComponentModel.DataAnnotations;

namespace GPW_API.Core.Dtos
{
    public class GpwCompanyDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Abrreviation { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public float PriceChange { get; set; }

        [Required]
        public float PriceChangePercent { get; set; }

        [Required]
        public int TransactionNumber { get; set; }

        [Required]
        public float Turnover { get; set; }

        [Required]
        public float OpeningPrice { get; set; }

        [Required]
        public float MaxPrice { get; set; }

        [Required]
        public float MinPrice { get; set; }

        [Required]
        public string RefreshTime { get; set; }
    }
}
