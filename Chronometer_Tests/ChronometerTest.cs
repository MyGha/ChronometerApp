using Xunit;
using Services.Interfaces;
using Services.Implementation;

namespace Chronometer_Tests
{
    public class ChronometerTest
    {
        private readonly IChronometerService ChronoService;

        public ChronometerTest()
        {
            ChronoService = ChronometerService.Create(null);
        }

        [Fact]
        public void When_ChronometerService_Class_is_instanciated_then_Value_is_set_to_Zero()
        {
            Assert.Equal("00:00:00", ChronoService.Value);
        }

        [Theory]
        [InlineData(1, "00:00:01")]
        [InlineData(6, "00:00:06")]
        [InlineData(59, "00:00:59")]
        [InlineData(60, "00:01:00")]
        [InlineData(61, "00:01:01")]
        [InlineData(86, "00:01:26")]
        [InlineData(3599, "00:59:59")]
        [InlineData(3600, "01:00:00")]
        [InlineData(3601, "01:00:01")]
        [InlineData(4810, "01:20:10")]
        [InlineData(86399, "23:59:59")]
        [InlineData(86400, "00:00:00")]
        [InlineData(86401, "00:00:01")]
        [InlineData(86580, "00:03:00")]
        public void When_passed_x_seconds_to_ChronometerService_Class_Then_it_returns_correct_Hour_Min_Sec_Format(int seconds, string result)
        {
            ChronoService.SetCurrentSecond(seconds);
            Assert.Equal(result, ChronoService.Value);
        }
    }
}
