using System;
using System.Collections.Generic;
using System.Text;
using Euromonitor.Assessment.Domain.V3;

namespace Euromonitor.Assessment.Domain
{
    public interface ICalculateDifferenceBetter
    {
        Response GetDifference(int lowerBound, int upperBound = 5);
    }
}
