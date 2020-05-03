using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using ParametersAndTools;

namespace AutocadPlugin.UnitTests
{
    [TestFixture]
    [Description("Модульные тесты класса Parameters")]
    public class ParametersTests
    {

        Parameters _parameters;

        Parameter _mainPartHeight;

        Parameter _mainPartWidth;
        
        Parameter _mainPartLength;
        
        Parameter _legsDiameter;
        
        Parameter _legsHeight;
        
        Parameter _headboardHeight;
        
        Parameter _headboardThickness;
        
        Parameter _personsHeight;
        
        Parameter _berthCount;

        [SetUp]
        public void CreateParameters() 
        {
            _parameters = new Parameters();

            _mainPartHeight = new Parameter(ParametersConstants.MainPartHeightMin,
                ParametersConstants.MainPartHeightMax);

            _mainPartWidth = new Parameter(ParametersConstants.MainPartWidthMin,
                ParametersConstants.MainPartWidthMax);

            _mainPartLength = new Parameter(ParametersConstants.MainPartLengthMin,
                ParametersConstants.MainPartLengthMax);

            _legsDiameter = new Parameter(ParametersConstants.LegsDiameterMin,
                ParametersConstants.LegsDiameterMax);

            _legsHeight = new Parameter(ParametersConstants.LegsHeightMin,
                ParametersConstants.LegsHeightMax);

            _headboardHeight = new Parameter(ParametersConstants.HeadboardHeightMin,
                ParametersConstants.HeadboardHeightMax);

            _headboardThickness =
                new Parameter(ParametersConstants.HeadboardThicknessMin,
                    ParametersConstants.HeadboardThicknessMax);

            _personsHeight = new Parameter(ParametersConstants.PersonsHeightMin,
                ParametersConstants.PersonsHeightMax);

            _berthCount = new Parameter(ParametersConstants.BerthCountMin,
                ParametersConstants.BerthCountMax);

            _parameters.ModelParameters.Add(ParameterType.MainPartHeight, _mainPartHeight);
            _parameters.ModelParameters.Add(ParameterType.MainPartWidth, _mainPartWidth);
            _parameters.ModelParameters.Add(ParameterType.MainPartLength, _mainPartLength);
            _parameters.ModelParameters.Add(ParameterType.LegsDiameter, _legsDiameter);
            _parameters.ModelParameters.Add(ParameterType.LegsHeight, _legsHeight);
            _parameters.ModelParameters.Add(ParameterType.HeadboardHeight,
                _headboardHeight);

            _parameters.ModelParameters.Add(ParameterType.HeadboardThickness,
                _headboardThickness);

            _parameters.ModelParameters.Add(ParameterType.PersonsHeight,
                _personsHeight);

            _parameters.ModelParameters.Add(ParameterType.BerthCount,
                _berthCount);
        }

        [TestCase]
        [Description("Тест функции SetAverageParameters")]
        public void SetAverageParametersTest()
        {
            _parameters.SetAverageParameters();

            var averageParameters = new List<double>
            {
                (ParametersConstants.MainPartHeightMin + ParametersConstants.MainPartHeightMax)/2,

                (ParametersConstants.MainPartWidthMin + ParametersConstants.MainPartWidthMax)/2,

                (ParametersConstants.MainPartLengthMin + ParametersConstants.MainPartLengthMax)/2,

                (ParametersConstants.LegsDiameterMin + ParametersConstants.LegsDiameterMax)/2,

                (ParametersConstants.LegsHeightMin + ParametersConstants.LegsHeightMax)/2,

                (ParametersConstants.HeadboardHeightMin + ParametersConstants.HeadboardHeightMax)/2,

                (ParametersConstants.HeadboardThicknessMin + ParametersConstants.HeadboardThicknessMax)/2,

                ParametersConstants.PersonsHeightAvg,

                ParametersConstants.BerthAvg,
            };

            Assert.AreEqual(averageParameters[0], _parameters.ModelParameters[ParameterType.MainPartHeight].Value);
            Assert.AreEqual(averageParameters[1], _parameters.ModelParameters[ParameterType.MainPartWidth].Value);
            Assert.AreEqual(averageParameters[2], _parameters.ModelParameters[ParameterType.MainPartLength].Value);
            Assert.AreEqual(averageParameters[3], _parameters.ModelParameters[ParameterType.LegsDiameter].Value);
            Assert.AreEqual(averageParameters[4], _parameters.ModelParameters[ParameterType.LegsHeight].Value);
            Assert.AreEqual(averageParameters[5], _parameters.ModelParameters[ParameterType.HeadboardHeight].Value);
            Assert.AreEqual(averageParameters[6], _parameters.ModelParameters[ParameterType.HeadboardThickness].Value);
            Assert.AreEqual(averageParameters[7], _parameters.ModelParameters[ParameterType.PersonsHeight].Value);
            Assert.AreEqual(averageParameters[8], _parameters.ModelParameters[ParameterType.BerthCount].Value);
        }

        [TestCase]
        [Description("Тест функции ValidateParameters в случае корректных параметров")]
        public void ValidateParametersTest() {
            _parameters.SetAverageParameters();
            _parameters.ModelParameters[ParameterType.MainPartLength].Value += 30;
            Assert.DoesNotThrow(() =>
            {
                _parameters.ValidateParameters();
            });
        }

        [TestCase]
        [Description("Тест функции ValidateParameters в случае если отстуствует один из требуемых параметров")]
        public void ValidateParametersNotEnoughtParametersTest()
        {
            _parameters.ModelParameters.Remove(ParameterType.MainPartHeight);
            Assert.Throws<ArgumentException>(() => {
                _parameters.ValidateParameters();
            });
        }

        [TestCase]
        [Description("Тест функции ValidateParameters в случае если ширина кровати не удовлетворяет количеству спальных мест")]
        public void ValidateParametersTooSmallWidthParameterTest() 
        {
            _parameters.SetAverageParameters();

            _parameters.ModelParameters[ParameterType.MainPartWidth].Value = ParametersConstants.MainPartWidthMin;

            Assert.Throws<ArgumentException>(() => {
                _parameters.ValidateParameters();
            });
        }

        [TestCase]
        [Description("Тест функции ValidateParameters в случае если длина кровати не удовлетворяет росту человека")]
        public void ValidateParametersTooSmallLengthParameterTest() 
        {
            _parameters.SetAverageParameters();

            _parameters.ModelParameters[ParameterType.MainPartLength].Value = ParametersConstants.MainPartLengthMin;

            Assert.Throws<ArgumentException>(() => {
                _parameters.ValidateParameters();
            });
        }
    }
}