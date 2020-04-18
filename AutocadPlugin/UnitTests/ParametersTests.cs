using System.Threading.Tasks;
using NUnit.Framework;
using ParametersAndTools;

namespace AutocadPlugin.UnitTests
{
    [TestFixture]
    [Description("Модульные тесты класса Parameters")]
    public class ParametersTests
    {
        [TestCase]
        [Description("Тест функции SetAverageParameters")]
        public async Task SetAverageParametersTest()
        {
            var parameters = new Parameters();

            var parameter1 = new Parameter(0, 2);
            var parameter2 = new Parameter(100, 800);
            var parameter3 = new Parameter(0, 1);

            parameters.ModelParameters.Add(ParameterType.HeadboardHeight, parameter1);
            parameters.ModelParameters.Add(ParameterType.MainPartHeight, parameter2);
            parameters.ModelParameters.Add(ParameterType.HeadboardThickness, parameter3);

            parameters.SetAverageParameters();

            Assert.AreEqual(1, parameters.ModelParameters[ParameterType.HeadboardHeight]);
            Assert.AreEqual(450, parameters.ModelParameters[ParameterType.MainPartHeight]);
            Assert.AreEqual(0.5, parameters.ModelParameters[ParameterType.HeadboardThickness]);
        }
    }
}