using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TenderApp.Core.Utilities.Security
{
    public class ValidateHelper
    {
        public static List<string> SendValidateMessage(ValidationResult validResult)
        {
            List<string> errorsMessage = new();
            foreach (var error in validResult.Errors)
            {
                errorsMessage.Add(error.ErrorMessage);
            }
            return errorsMessage;
        } 
    }
}
