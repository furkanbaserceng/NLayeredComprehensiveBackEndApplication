using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class ValidateRuleMessages
    {

        public static string ProductNameNotEmpty = "Product name can not be empty.!";
        public static string ProductNameMinLength = "Product name must be a minimum of 3 characters.!";
        public static string ProductNameGraterThan = "Product unit price must be greater than zero.";
        public static string ProductNameIfCIdGraterThan = "If the category number is one, product price must be 20 or more.";


    }
}
