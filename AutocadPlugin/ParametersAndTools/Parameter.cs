using System;

namespace ParametersAndTools
{
    public class Parameter
    {
        /// <summary>
        ///     Минимально допустимое значение параметра
        /// </summary>
        private readonly double _minValue;

        /// <summary>
        ///     Максимально допустимое значение параметра
        /// </summary>
        private readonly double _maxValue;

        /// <summary>
        ///     Значение параметра
        /// </summary>
        private double _value;

        public Parameter(double minValue, double maxValue)
        {
            _maxValue = maxValue;
            _minValue = minValue;
        }

        /// <summary>
        ///     Установить среднее значение параметра
        /// </summary>
        public void SetAverageValue()
        {
            Value = (_minValue + _maxValue) / 2;
        }

        /// <summary>
        ///     Значение параметра
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value <= _maxValue && value >= _minValue)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Значение не может быть меньше чем " + _minValue +
                        " и больше чем " + _maxValue + ". Значение: " + value);
                }
            }
        }
    }
}