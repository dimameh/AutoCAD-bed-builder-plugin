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

            var mainPartHeight = new Parameter(10, 30);
            var mainPartWidth = new Parameter(60, 230);
            var mainPartLength = new Parameter(120, 230);
            var legsDiameter = new Parameter(5, 10);
            var legsHeight = new Parameter(10, 30);
            var headboardHeight = new Parameter(60, 100);
            var headboardThickness = new Parameter(5, 30);
            var personsHeight = new Parameter(90, 200);
            var berthCount = new Parameter(1, 2);

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
                (10 + 30d) / 2,
                (60 + 230d) / 2,
                (120 + 230d) / 2,
                (5 + 10d) / 2,
                (10 + 30d) / 2,
                (60 + 100d) / 2,
                (5 + 30d) / 2,
                170,
                1
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

            _parameters.ModelParameters[ParameterType.MainPartWidth].Value = 60;

            Assert.Throws<ArgumentException>(() => { _parameters.ValidateParameters(); });
        }

        [TestCase]
        [Description(
            "Тест функции ValidateParameters в случае если длина кровати не удовлетворяет росту человека")]
        public void ValidateParametersTooSmallLengthParameterTest()
        {
            _parameters.SetAverageParameters();

            _parameters.ModelParameters[ParameterType.MainPartLength].Value = 120;

            Assert.Throws<ArgumentException>(() => { _parameters.ValidateParameters(); });
        }
    }
}