using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Models
{
    public class Mobile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]

        public Manufacturer Manufacturer { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}
