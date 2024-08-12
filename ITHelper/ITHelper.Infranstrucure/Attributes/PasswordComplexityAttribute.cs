using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.Attributes
{
    public class PasswordComplexityAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString())) return false;

            var password = value.ToString();
            var hasMinimumLength = password.Length >= 8;
            var hasUpperCaseLetter = Regex.IsMatch(password, "[A-Z]");
            var hasSpecialCharacter = Regex.IsMatch(password, "[^a-zA-Z0-9]");

            return hasMinimumLength && hasUpperCaseLetter && hasSpecialCharacter;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Şifre en az 8 karakterden oluşmalı, en az bir büyük harf ve en az bir özel karakter içermelidir.";
        }

    }
}
