using System;

namespace Euromonitor.Assessment.Domain.V1
{

    /// <summary>
    /// V1 starts out like most projects, the requirement is simple.
    /// And the solution reflects the same.
    /// </summary>
    public class DifferenceCalculation : ICalculateDifference
    {
        public int GetDifference(int lowerBound, int upperBound = 5)
        {
            if (lowerBound > upperBound) 
                throw new InvalidOperationException("lowerBound cannot be greater than upperBound");

            if (lowerBound >= 0) 
                return upperBound - lowerBound;

            if (lowerBound < 0 && upperBound >= 0) 
                return upperBound + (lowerBound * -1);

            return (lowerBound * -1) - (upperBound * -1);
        }
    }
}
