using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Min18GodinaAkoSiClan : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var kupac = (Kupac)validationContext.ObjectInstance;

            if (kupac.TipClanstvaId == TipClanstva.Nepoznato || 
                kupac.TipClanstvaId == TipClanstva.PlatiOdmah)
                return ValidationResult.Success;

            if (kupac.DatumRodenja == null)
                return new ValidationResult("Datum rođenja je obavezan.");

            var dob = DateTime.Today.Year - kupac.DatumRodenja.Value.Year;

            return (dob >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Kupac mora imati minimalno 18 godina kako bi postao clan.");
        }
    }
}