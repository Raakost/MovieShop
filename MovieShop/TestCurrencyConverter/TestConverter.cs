using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;

namespace TestCurrencyConverter
{
    [TestFixture]
    public class TestConverter
    {
        [Test]
        public void can_convert_from_DKK_to_USD()
        {
            var converter = new CurrencyConverter("USD");
            Assert.IsTrue(14 - converter.Convert(100) < 0.0001);
        }

        [Test]
        public void can_convert_from_DKK_to_EURO()
        {
            var converter = new CurrencyConverter("EURO");
            Assert.IsTrue(13 - converter.Convert(100) < 0.0001);
        }
    }
}
