using System;
using Euromonitor.Assessment.Domain.V1;
using Xunit;

namespace Euromonitor.Assessment.Tests.V1
{
    public class DifferenceCalculationTest
    {
        [Theory]
        [InlineData(1, 4, 5)]
        [InlineData(3, 1, 4)]
        [InlineData(1, 0, 1)]
        [InlineData(6, -5, 1)]
        [InlineData(1, -1, 0)]
        [InlineData(1, -5, -4)]
        public void GetDifference_HappyPath(int expected, int lowerBound, int upperBound)
        {
            var actual = new Domain.V1.DifferenceCalculation().GetDifference(lowerBound, upperBound);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDifference_InvalidOperation()
        {
            var calculator = new DifferenceCalculation();

            Assert.Throws<InvalidOperationException>(() =>  calculator.GetDifference(6));
        }
    }
}
