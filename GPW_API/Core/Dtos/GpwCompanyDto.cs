using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public DateTime RefreshTime { get; set; }
    }
}
