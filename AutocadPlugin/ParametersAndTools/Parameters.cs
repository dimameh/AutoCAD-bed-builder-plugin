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
                ModelParameters[key].SetAverageValue();
            }
        }

        /// <summary>
        ///     Параметры модели
        /// </summary>
        public Dictionary<ParameterType, Parameter> ModelParameters { get; } =
            new Dictionary<ParameterType, Parameter>();
    }
}