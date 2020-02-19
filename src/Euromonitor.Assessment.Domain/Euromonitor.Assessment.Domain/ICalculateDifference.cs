using System;
using System.Collections.Generic;
using System.Text;

namespace Euromonitor.Assessment.Domain
{
    public interface ICalculateDifference
    {
        int GetDifference(int lowerBound, int upperBound = 5);
    }
}
