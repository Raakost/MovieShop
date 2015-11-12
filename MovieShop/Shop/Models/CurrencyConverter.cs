using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Shop.Models
{

    public class CurrencyConverter
    {
        public Dictionary<string, double> Currencies = new Dictionary<string, double>();
        public string CurrentCurrency { get; set; }

        public CurrencyConverter(string currentCurrency)
        {
            if (currentCurrency == null)
            {
                currentCurrency = "DKK";
            }

            CurrentCurrency = currentCurrency;
            Currencies.Add("DKK", 1d);
            Currencies.Add("USD", 0.14d);
            Currencies.Add("EURO", 0.13d);

        }

        public double Convert(double price)
        {
            return Currencies[CurrentCurrency] * price;
        }

    }
}