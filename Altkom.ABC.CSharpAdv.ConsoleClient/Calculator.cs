using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class TaxCalculator
    {
        public decimal CalculateTax(decimal amount, decimal tax)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            return amount * tax + 1;
            // throw new NotImplementedException();
        }
    }
}
