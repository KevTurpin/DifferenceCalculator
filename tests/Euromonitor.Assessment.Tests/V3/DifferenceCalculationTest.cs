using Euromonitor.Assessment.Domain;
using Euromonitor.Assessment.Domain.V3;
using Microsoft.Extensions.Configuration;
using Xunit;


namespace Euromonitor.Assessment.Tests.V3
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
        [InlineData(0, 1, 1)]
        [InlineData(0, -1, -1)]
        public void GetDifference_HappyPath(int expected, int lowerBound, int upperBound)
        {
            var actual = new Domain.V3.DifferenceCalculation().GetDifference(lowerBound, upperBound);

            Assert.Equal(expected, actual.CalculatedAmount);
        }

        [Fact]
        public void GetDifference_ValidationFail()
        {
            var actual = new DifferenceCalculation().GetDifference(8);

            Assert.Equal(ResponseType.ValidationFail, actual.Outcome);
        }

        [Theory]
        [InlineData(ResponseType.ValidationFail, -101, 10)]
        [InlineData(ResponseType.ValidationFail, -100, -100)]
        [InlineData(ResponseType.ValidationFail, -99, -100)]
        public void GetDifference_LowerlimitExceeded(ResponseType expected, int lowerBound, int upperBound)
        {
            var actual = new DifferenceCalculation().GetDifference(lowerBound, upperBound);

            Assert.Equal(expected, actual.Outcome);
        }

        [Theory]
        [InlineData(ResponseType.ValidationFail, 101, 10)]
        [InlineData(ResponseType.ValidationFail, 100, 100)]
        [InlineData(ResponseType.ValidationFail, 100, 101)]
        public void GetDifference_UpperlimitExceeded(ResponseType expected, int lowerBound, int upperBound)
        {
            var actual = new DifferenceCalculation().GetDifference(lowerBound, upperBound);

            Assert.Equal(expected, actual.Outcome);
        }
    }
}
