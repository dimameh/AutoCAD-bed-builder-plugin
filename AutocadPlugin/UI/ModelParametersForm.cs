using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutocadPlugin.Drawer;
using Autodesk.AutoCAD.ApplicationServices;
using ModelController;
using ParametersAndTools;

namespace UI
{
    public partial class ModelParametersForm : Form
    {
        /// <summary>
        ///     Текущий документ
        /// </summary>
        private readonly Document _document;

        /// <summary>
        ///     Параметры модели
        /// </summary>
        private Parameters _parameters;

        /// <summary>
        ///     Поля ввода
        /// </summary>
        private readonly Dictionary<ParameterType, TextBox> _fields =
            new Dictionary<ParameterType, TextBox>();

        /// <summary>
        ///     Последние значения полей ввода. Используются для валидации
        /// </summary>
        private readonly Dictionary<TextBox, string> _lastTextBoxValues =
            new Dictionary<TextBox, string>();

        public ModelParametersForm(Document document)
        {
            _document = document;
            InitializeComponent();
            Init();
        }

        /// <summary>
        ///     Инициализация параметров модели
        /// </summary>
        private void InitParameters()
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

            _parameters.SetAverageParameters();
        }

        /// <summary>
        ///     Инициализация полей ввода
        /// </summary>
        private void InitFields()
        {
            _fields.Add(ParameterType.MainPartHeight, _mainPartHeightTextBox);
            _fields.Add(ParameterType.MainPartWidth, _mainPartWidthTextBox);
            _fields.Add(ParameterType.MainPartLength, _mainPartLengthTextBox);
            _fields.Add(ParameterType.LegsDiameter, _legsDiameterTextBox);
            _fields.Add(ParameterType.LegsHeight, _legsHeightTextBox);
            _fields.Add(ParameterType.HeadboardHeight, _headboardHeightTextBox);
            _fields.Add(ParameterType.HeadboardThickness, _headboardThicknessTextBox);
            _fields.Add(ParameterType.PersonsHeight, _personsHeightTextBox);
            _fields.Add(ParameterType.BerthCount, _berthCountTextBox);

            foreach (var key in _fields.Keys)
            {
                _fields[key].Text = _parameters.ModelParameters[key].Value.ToString(CultureInfo.InvariantCulture);
            }

            _personsHeightTextBox.TextChanged += PersonsHeightTextBox_TextChanged;
            _berthCountTextBox.TextChanged += BerthCountTextBox_TextChanged;
        }

        /// <summary>
        ///     Инициализация
        /// </summary>
        private void Init()
        {
            InitParameters();
            InitFields();
        }

        /// <summary>
        ///     Заполнить параметры значениями из полей ввода
        /// </summary>
        private void FillParameters()
        {
            foreach (var key in _parameters.ModelParameters.Keys)
            {
                _parameters.ModelParameters[key].Value = double.Parse(_fields[key].Text);
            }
        }

        /// <summary>
        ///     Валидация целочисленных полей ввода
        /// </summary>
        /// <param name="textBox">Поле ввода</param>
        private void ValidateIntegerTextBox(TextBox textBox)
        {
            if (textBox.Text.Length == 0)
            {
                return;
            }

            if (!Regex.IsMatch(textBox.Text, @"^[1-9]\d*$"))
            {
                textBox.Text = _lastTextBoxValues[textBox];
            }
        }

        /// <summary>
        ///     Сохранить последнее значение поля ввода
        /// </summary>
        /// <param name="textBox">Поле ввода</param>
        private void SaveLastTextBoxValue(TextBox textBox)
        {
            _lastTextBoxValues[textBox] = textBox.Text;
        }

        /// <summary>
        ///     Расчитать длину кровати по введеному росту
        /// </summary>
        /// <param name="textBox">Поле ввода</param>
        private void ApplyPersonsHeight(TextBox textBox)
        {
            if (textBox.Text.Length == 0)
            {
                return;
            }

            SaveLastTextBoxValue(_mainPartLengthTextBox);
            _fields[ParameterType.MainPartLength].Text =
                (double.Parse(textBox.Text) +
                 ParametersConstants.PersonsHeightBedLengthDiff)
                .ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Расчитать ширину кровати по количеству спальных мест
        /// </summary>
        /// <param name="textBox">Поле ввода</param>
        private void ApplyBerthCount(TextBox textBox)
        {
            if (textBox.Text.Length == 0)
            {
                return;
            }

            SaveLastTextBoxValue(_mainPartWidthTextBox);
            _fields[ParameterType.MainPartWidth].Text =
                (double.Parse(textBox.Text) * ParametersConstants.BedWidthPerBerth)
                .ToString(CultureInfo.InvariantCulture);
        }

        #region События кнопок

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var modelBuilder = new ModelBuilder(_document, _parameters);
            try
            {
                FillParameters();
                _parameters.ValidateParameters();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show(
                    "Введенные параметры выходят за границы доступного диапазона значений",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message);
                return;
            }

            modelBuilder.BuildBed();
            Close();
        }


        private void showButton_Click(object sender, EventArgs e) 
        {
            try {
                FillParameters();
                _parameters.ValidateParameters();
            } catch (ArgumentOutOfRangeException exception) {
                MessageBox.Show(
                    "Введенные параметры выходят за границы доступного диапазона значений",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            } catch (ArgumentException argumentException) {
                MessageBox.Show(argumentException.Message);
                return;
            }

            var modelDrawer = new ModelDrawer(_parameters, picture);
            modelDrawer.DrawPicture();
        }

        #endregion

        #region Валидация

        private void TextBox_PreviewKeyDown(object sender,
            PreviewKeyDownEventArgs e)
        {
            SaveLastTextBoxValue(sender as TextBox);
        }

        private void BerthCountTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateIntegerTextBox(sender as TextBox);
            ApplyBerthCount(sender as TextBox);
        }

        private void PersonsHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateIntegerTextBox(sender as TextBox);
            ApplyPersonsHeight(sender as TextBox);
        }

        private void TextBoxDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar == ',' ? e.KeyChar = '.' : e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' &&
                e.KeyChar != (char) Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void DoubleTextBox_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            try
            {
                FillParameters();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show(exception.ParamName,
                    "Ошибка ввода поля: " + textBox.AccessibleDescription,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}