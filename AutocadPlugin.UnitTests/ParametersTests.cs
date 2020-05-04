using System;
using System.Collections.Generic;
using NUnit.Framework;
using ParametersAndTools;

namespace AutocadPlugin.UnitTests
{
    [TestFixture]
    [Description("Модульные тесты класса Parameters")]
    public class ParametersTests
    {
        private Parameters _parameters;

        [SetUp]
        public void CreateParameters()
        {
            _parameters = new Parameters();

            var mainPartHeight = new Parameter(ParametersConstants.MainPartHeightMin,
                ParametersConstants.MainPartHeightMax);

            var mainPartWidth = new Parameter(ParametersConstants.MainPartWidthMin,
                ParametersConstants.MainPartWidthMax);

            var mainPartLength = new Parameter(ParametersConstants.MainPartLengthMin,
                ParametersConstants.MainPartLengthMax);

            var legsDiameter = new Parameter(ParametersConstants.LegsDiameterMin,
                ParametersConstants.LegsDiameterMax);

            var legsHeight = new Parameter(ParametersConstants.LegsHeightMin,
                ParametersConstants.LegsHeightMax);

            var headboardHeight = new Parameter(ParametersConstants.HeadboardHeightMin,
                ParametersConstants.HeadboardHeightMax);

            var headboardThickness =
                new Parameter(ParametersConstants.HeadboardThicknessMin,
                    ParametersConstants.HeadboardThicknessMax);

            var personsHeight = new Parameter(ParametersConstants.PersonsHeightMin,
                ParametersConstants.PersonsHeightMax);

            var berthCount = new Parameter(ParametersConstants.BerthCountMin,
                ParametersConstants.BerthCountMax);

            _parameters.ModelParameters.Add(ParameterType.MainPartHeight, mainPartHeight);
            _parameters.ModelParameters.Add(ParameterType.MainPartWidth, mainPartWidth);
            _parameters.ModelParameters.Add(ParameterType.MainPartLength, mainPartLength);
            _parameters.ModelParameters.Add(ParameterType.LegsDiameter, legsDiameter);
            _parameters.ModelParameters.Add(ParameterType.LegsHeight, legsHeight);
            _parameters.ModelParameters.Add(ParameterType.HeadboardHeight,
                headboardHeight);

            _parameters.ModelParameters.Add(ParameterType.HeadboardThickness,
                headboardThickness);

            _parameters.ModelParameters.Add(ParameterType.PersonsHeight,
                personsHeight);

            _parameters.ModelParameters.Add(ParameterType.BerthCount,
                berthCount);
        }

        [TestCase]
        [Description("Тест функции SetAverageParameters")]
        public void SetAverageParametersTest()
        {
            _parameters.SetAverageParameters();

            var averageParameters = new List<double>
            {
                (ParametersConstants.MainPartHeightMin +
                 ParametersConstants.MainPartHeightMax) / 2,
                (ParametersConstants.MainPartWidthMin +
                 ParametersConstants.MainPartWidthMax) / 2,
                (ParametersConstants.MainPartLengthMin +
                 ParametersConstants.MainPartLengthMax) / 2,
                (ParametersConstants.LegsDiameterMin +
                 ParametersConstants.LegsDiameterMax) / 2,
                (ParametersConstants.LegsHeightMin +
                 ParametersConstants.LegsHeightMax) / 2,
                (ParametersConstants.HeadboardHeightMin +
                 ParametersConstants.HeadboardHeightMax) / 2,
                (ParametersConstants.HeadboardThicknessMin +
                 ParametersConstants.HeadboardThicknessMax) / 2,
                ParametersConstants.PersonsHeightAvg,
                ParametersConstants.BerthAvg
            };

            Assert.AreEqual(averageParameters[0],
                _parameters.ModelParameters[ParameterType.MainPartHeight].Value);

            Assert.AreEqual(averageParameters[1],
                _parameters.ModelParameters[ParameterType.MainPartWidth].Value);

            Assert.AreEqual(averageParameters[2],
                _parameters.ModelParameters[ParameterType.MainPartLength].Value);

            Assert.AreEqual(averageParameters[3],
                _parameters.ModelParameters[ParameterType.LegsDiameter].Value);

            Assert.AreEqual(averageParameters[4],
                _parameters.ModelParameters[ParameterType.LegsHeight].Value);

            Assert.AreEqual(averageParameters[5],
                _parameters.ModelParameters[ParameterType.HeadboardHeight].Value);

            Assert.AreEqual(averageParameters[6],
                _parameters.ModelParameters[ParameterType.HeadboardThickness].Value);

            Assert.AreEqual(averageParameters[7],
                _parameters.ModelParameters[ParameterType.PersonsHeight].Value);

            Assert.AreEqual(averageParameters[8],
                _parameters.ModelParameters[ParameterType.BerthCount].Value);
        }

        [TestCase]
        [Description("Тест функции ValidateParameters в случае корректных параметров")]
        public void ValidateParametersTest()
        {
            _parameters.SetAverageParameters();
            _parameters.ModelParameters[ParameterType.MainPartLength].Value += 30;
            Assert.DoesNotThrow(() => { _parameters.ValidateParameters(); });
        }

        [TestCase]
        [Description(
            "Тест функции ValidateParameters в случае если отстуствует один из требуемых параметров")]
        public void ValidateParametersNotEnoughtParametersTest()
        {
            _parameters.ModelParameters.Remove(ParameterType.MainPartHeight);
            Assert.Throws<ArgumentException>(() => { _parameters.ValidateParameters(); });
        }

        [TestCase]
        [Description(
            "Тест функции ValidateParameters в случае если ширина кровати не удовлетворяет количеству спальных мест")]
        public void ValidateParametersTooSmallWidthParameterTest()
        {
            _parameters.SetAverageParameters();

            _parameters.ModelParameters[ParameterType.MainPartWidth].Value =
                ParametersConstants.MainPartWidthMin;

            Assert.Throws<ArgumentException>(() => { _parameters.ValidateParameters(); });
        }

        [TestCase]
        [Description(
            "Тест функции ValidateParameters в случае если длина кровати не удовлетворяет росту человека")]
        public void ValidateParametersTooSmallLengthParameterTest()
        {
            _parameters.SetAverageParameters();

            _parameters.ModelParameters[ParameterType.MainPartLength].Value =
                ParametersConstants.MainPartLengthMin;

            Assert.Throws<ArgumentException>(() => { _parameters.ValidateParameters(); });
        }
    }
}