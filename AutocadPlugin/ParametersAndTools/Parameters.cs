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
                    ModelParameters[key].Value = 1;
                }
                else if (key == ParameterType.PersonsHeight)
                {
                    ModelParameters[key].Value = 170;
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

                if (ModelParameters[ParameterType.BerthCount].Value * 60 >
                    ModelParameters[ParameterType.MainPartWidth].Value)
                {
                    throw new ArgumentException(
                        "Ширина кровати слишком мала для указанного количества спальных мест");
                }

                if (ModelParameters[ParameterType.PersonsHeight].Value + 30 >
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