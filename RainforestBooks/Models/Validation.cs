using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RainforestBooks.Models
{
    public class Validation
    {
        public static Regex emailCheck = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        public static Regex phoneCheck = new Regex(@"^\d{2,3}-\d{6,7}$");
        public static Regex passwordCheck = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
        public static Regex numberCheck = new Regex(@"^[0-9]*$");
        public static Match match;


        public string NumberValidator(string input)
        {
            string message = null;

            match = numberCheck.Match(input);

            if (match.Success)
            {
                message = null;
            }
            else
            {
                message = "** Invalid number entered in" + Environment.NewLine;
            }
            return message;
        }

        public string EmailValidator(string emailInput)
        {
            string message = null;

            match = emailCheck.Match(emailInput);

            if (match.Success)
            {
                message = null;
            }
            else
            {
                message = "Email entered is invalid" + Environment.NewLine;
            }

            return message;
        }

        public string PhoneValidator(string phoneInput)
        {
            string message = null;
            string phoneRegEx = ConfigurationManager.AppSettings["PhoneRegEx"];

            match = phoneCheck.Match(phoneInput);
            if (match.Success)
            {
                message = null;
            }
            else
            {
                message = "Please enter phone in XXX-XXXXXXX or XX-XXXXXX format" + Environment.NewLine;
            }


            return message;
        }
    }
}