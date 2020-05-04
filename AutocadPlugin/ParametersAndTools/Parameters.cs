using System;
using System.Collections.Generic;

namespace ParametersAndTools
{
    /// <summary>
    ///     Список параметров модели
    /// </summary>
    public class Parameters
    {
        /// <summary>
        ///     Выставить средние значения параметров
        /// </summary>
        public void SetAverageParameters()
        {
            if (ModelParameters.Count < 0)
            {
                return;
            }

            foreach (var key in ModelParameters.Keys)
            {
                if (key == ParameterType.BerthCount)
                {
                    ModelParameters[key].Value = ParametersConstants.BerthAvg;
                }
                else if (key == ParameterType.PersonsHeight)
                {
                    ModelParameters[key].Value = ParametersConstants.PersonsHeightAvg;
                }
                else
                {
                    ModelParameters[key].SetAverageValue();
                }
            }
        }

        /// <summary>
        ///     Валидация параметров
        /// </summary>
        public void ValidateParameters()
        {
            foreach (ParameterType parameterType in Enum.GetValues(typeof(ParameterType)))
            {
                if (!ModelParameters.ContainsKey(parameterType))
                {
                    throw new ArgumentException(
                        "Не хватает одного из параметров: " + parameterType);
                }

                if (ModelParameters[ParameterType.BerthCount].Value *
                    ParametersConstants.BedWidthPerBerth >
                    ModelParameters[ParameterType.MainPartWidth].Value)
                {
                    throw new ArgumentException(
                        "Ширина кровати слишком мала для указанного количества спальных мест");
                }

                if (ModelParameters[ParameterType.PersonsHeight].Value +
                    ParametersConstants.PersonsHeightBedLengthDiff >
                    ModelParameters[ParameterType.MainPartLength].Value)
                {
                    throw new ArgumentException(
                        "Длина кровати слишком мала для указанного роста человека");
                }
            }
        }

        /// <summary>
        ///     Параметры модели
        /// </summary>
        public Dictionary<ParameterType, Parameter> ModelParameters { get; } =
            new Dictionary<ParameterType, Parameter>();
    }
}