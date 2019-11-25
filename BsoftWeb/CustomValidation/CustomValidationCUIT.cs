using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BsoftWeb.CustomValidation
{
    public class CustomValidationCUIT : ValidationAttribute
    {
        public CustomValidationCUIT():
                base("{0} el cuit-cuil no es valido")
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
                if (!Validar(value.ToString()))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
                else
                {
                    return ValidationResult.Success;
                }
            return ValidationResult.Success;
        }

    //    public CheckforCaps()
    //     : base("{0} contains invalid character.")   
    //{   
   
    //}   
   
    //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (value != null)
    //        {
    //            byte[] ASCIIValues = Encoding.ASCII.GetBytes(value.ToString());
    //            foreach (byte b in ASCIIValues)
    //            {
    //                if (b <= 65 || b >= 90)
    //                {
    //                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
    //                    return new ValidationResult(errorMessage);

    //                }
    //            }
    //        }
    //        return ValidationResult.Success;
    //    }


        private Boolean Validar(String cuit)
        {
            if (cuit == null)
            {
                return false;
            }
            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else
            {
                int calculado = CalcularDigitoCuit(cuit);
                int digito = int.Parse(cuit.Substring(10));
                /*compara el digiot calculado con el pasado en el parametro*/
                return calculado == digito;
            }
        }

        /*calcula el digito verificador para comparar*/
        private int CalcularDigitoCuit(String cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;
            for (int i = 0; i < mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }
            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
        }
    }
}
