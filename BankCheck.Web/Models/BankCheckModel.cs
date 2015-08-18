using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankCheck.Web.Models
{
    public class BankCheckModel
    {

        [Required]
        [Display(Name="Nombre de la Compañia")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name="Nombre del Cliente")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Monto")]
        public Decimal Amount { get; set; }

        [Display(Name = "Cantidad")]
        public string StringAmount { get; set; }


        [Required]
        [Display(Name = "Moneda")]
        public string Currency { get; set; }





    }



    
}