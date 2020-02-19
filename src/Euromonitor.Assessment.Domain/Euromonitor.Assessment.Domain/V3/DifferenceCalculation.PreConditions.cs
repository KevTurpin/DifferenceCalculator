using System;
using System.Collections.Generic;
using System.Text;

namespace Euromonitor.Assessment.Domain.V3
{
    public partial class DifferenceCalculation
    {
        private delegate string PreCondition(int lower, int upper);

        private class PreConditions
        {
            /// <summary>
            /// A Convenient way to access a List of all preconditions
            /// </summary>
            /// <returns></returns>
            public PreCondition[] AllPreConditions()
                => new PreCondition[]
                {
                    InputValidation, LowerLimits, UpperLimits
                };

            /// <summary>
            /// LowerBound must be less than UpperBound
            /// </summary>
            /// <param name="lowerBound"></param>
            /// <param name="upperBound"></param>
            /// <returns></returns>
            private string InputValidation(int lowerBound, int upperBound)
            {
                if (lowerBound > upperBound)
                    return "LowerBound parameter must be greater than the UpperBound parameter";

                return string.Empty;
            }
            
            /// <summary>
            /// I hard coded some new business rules that might get added later to demonstrate the value of this patter
            /// </summary>
            /// <param name="lowerBound"></param>
            /// <param name="upperBound"></param>
            /// <returns></returns>
            private string LowerLimits(int lowerBound, int upperBound)
            {
                if (lowerBound < -100)
                    return "The LowerBound lower limit has been exceeded";

                if (upperBound < -99)
                    return "The UpperBound lower limit has been exceeded";

                return string.Empty;
            }

            /// <summary>
            /// I hard coded some new business rules that might get added later to demonstrate the value of this patter
            /// </summary>
            /// <param name="lowerBound"></param>
            /// <param name="upperBound"></param>
            /// <returns></returns>
            private string UpperLimits(int lowerBound, int upperBound)
            {
                if (lowerBound > 99)
                    return "The UpperBound limit has been exceeded";

                if (upperBound > 100)
                    return "The UpperBound limit has been exceeded";

                return string.Empty;
            }

        }
        
    }
}
