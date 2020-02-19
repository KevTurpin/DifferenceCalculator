using System;
using System.Collections.Generic;
using System.Text;

namespace Euromonitor.Assessment.Domain.V3
{
    public partial class DifferenceCalculation
    {
        private delegate int Calculation(int lower, int upper);

        private static class Calculations
        {
            public static Calculation[] AllCalculations()
                => new Calculation[]
                {
                    BothPositive, BothNegative, OnlyLowerBoundIsNegative
                };

            public static int BothPositive(int lowerBound, int upperBound)
            {
                if (lowerBound >= 0 && upperBound > 0)
                    return upperBound - lowerBound;

                return 0;
            }

            public static int OnlyLowerBoundIsNegative(int lowerBound, int upperBound)
            {
                if (lowerBound < 0 && upperBound >= 0)
                    return upperBound + (lowerBound * -1);

                return 0;
            }

            public static int BothNegative(int lowerBound, int upperBound)
            {
                if (upperBound < 0 && lowerBound < 0)
                    return (lowerBound * -1) - (upperBound * -1);

                return 0;
            }

        }
        
    }
}
