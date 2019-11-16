using System;
using System.ComponentModel.DataAnnotations;

namespace GPW_API.Core.Models
{
    public class GpwCompany
    {
        public int Id { get; set; }

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
        public bool IsDeleated { get; set; }

        [Required]
        public DateTime RefreshTime { get; set; }
    }
}
