using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using ParametersAndTools;

namespace AutocadPlugin.UnitTests 
{
    [TestFixture]
    [Description("Модульные тесты класса Parameter")]
    class ParameterTests 
    {
        [Test]
        [Description("Тест функции SetAverageValue")]
        public void SetAverageValueTest() 
        {
            var parameter1 = new Parameter(0, 2);
            var parameter2 = new Parameter(100, 800);
            var parameter3 = new Parameter(0, 1);

            parameter1.SetAverageValue();
            parameter2.SetAverageValue();
            parameter3.SetAverageValue();

            Assert.AreEqual(1, parameter1.Value);
            Assert.AreEqual(450, parameter2.Value);
            Assert.AreEqual(0.5, parameter3.Value);
        }

        [Test]
        [Description("Тест свойства Value")]
        public void SetParameterValueTest() 
        {
            var parameter1 = new Parameter(0, 2);
            var parameter2 = new Parameter(100, 800);
            var parameter3 = new Parameter(0, 1);

            //Значение на допустимом интервале
            Assert.DoesNotThrow(() =>
            {
                parameter1.Value = 1;
            });
            
            //Значение ниже допустимого интервала
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                parameter2.Value = 1;
            });

            //Значение выше допустимого интервала
            Assert.Throws<ArgumentOutOfRangeException>(() => 
            {
                parameter3.Value = 8;
            });
        }
    }
}
