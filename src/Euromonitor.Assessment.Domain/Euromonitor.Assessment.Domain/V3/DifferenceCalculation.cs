using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace Euromonitor.Assessment.Domain.V3
{
    public partial class DifferenceCalculation : ICalculateDifferenceBetter
    {
        private readonly Calculation[] _calculations;
        private readonly PreCondition[] _preConditions;
        
        public DifferenceCalculation()
        {
            _calculations = Calculations.AllCalculations();
            _preConditions = new PreConditions().AllPreConditions();
        }

        public Response GetDifference(int lowerBound, int upperBound = 5)
        {
            try
            {
                var preConditionViolations = _preConditions
                    .Select(preCondition => preCondition.Invoke(lowerBound, upperBound))
                    .ToArray();
                
                if (preConditionViolations.Any(p => p.Length > 0)) return new Response(preConditionViolations);

                var difference = _calculations.Sum(calc => calc.Invoke(lowerBound, upperBound));

                return new Response(difference);
            }
            catch (Exception e)
            {
                return new Response(e);
            }
        }
    }
}
