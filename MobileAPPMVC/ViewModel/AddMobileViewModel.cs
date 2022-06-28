using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.ViewModel
{
    public class AddMobileViewModel
    {
        [Required(ErrorMessage = " Name is mandatory")]
        public string Name { get; set; }




        [Required(ErrorMessage = " Manufacturer is mandatory")]
        public int ManufacturerId { get; set; }

        [Required(ErrorMessage = " Amount is mandatory")]
        public double Amount { get; set; }

        public List<SelectListItem> ManufactureList { get; set; }

    }
}
