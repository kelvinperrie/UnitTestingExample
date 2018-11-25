using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingExample.data;

namespace UnitTestingExample.business
{
    public class ResultService
    {    
        private readonly ResultRepository _resultsRepository = new ResultRepository();
        public Result CreateResult(string nhi, string amount)
        {
            var result = new Result();
            result.nhi = nhi;
            int parsedAmount = 0;
            if(!int.TryParse(amount, out parsedAmount))
            {
                throw new Exception($"Couldn't parse amount of {amount} to an integer");
            }
            // don't allow zeros in amount
            if(parsedAmount < 0)
            {
                throw new Exception("Result amount cannot be set to zero");
            }
            result.amount = parsedAmount;
            result.created = DateTime.Now;
            result.isReal = IsRealPatient(result.nhi);
            result.active = true;
            _resultsRepository.Add(result);
            return result;
        }

        private bool IsRealPatient(string nhi)
        {
            return nhi.ToLower() != "prp1660";
        }
    }
}
