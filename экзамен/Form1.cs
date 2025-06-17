using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace экзамен
{
    public partial class Form1 : Form
    {
        private decimal _currentValue = 0;
        private List<string> _expressionParts = new List<string>();
        private bool _isNewInput = true;
        private bool _isDecimalEntered = false;
        private readonly CultureInfo _culture = CultureInfo.InvariantCulture;
        private bool _isNegativeInput = false;
        private bool _operationJustEntered = false;
        private bool _shouldResetOnNextInput = false;

        public Form1()
        {
            InitializeComponent();
            InitializeHistoryLabel();
            this.KeyPreview = true;
        }

        private void InitializeHistoryLabel()
        {
            lblHistory.Text = "";
            lblHistory.TextAlign = ContentAlignment.MiddleRight;
            lblHistory.AutoSize = false;
            lblHistory.Height = 30;
            lblHistory.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblHistory.ForeColor = Color.Gray;
            lblHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _operationJustEntered = false;

            // Если нужно сбросить (после равно и начала ввода цифры)
            if (_shouldResetOnNextInput)
            {
                ResetCalculator();
                _shouldResetOnNextInput = false;
            }

            if (_isNewInput)
            {
                txtDisplay.Text = _isNegativeInput ? "-" + button.Text : button.Text;
                _isNewInput = false;
                _isDecimalEntered = false;
                _isNegativeInput = false;
            }
            else
            {
                if (txtDisplay.Text == "0" && button.Text == "0")
                    return;

                if (txtDisplay.Text.Length < 16)
                {
                    if (txtDisplay.Text == "0" && button.Text != "0")
                        txtDisplay.Text = button.Text;
                    else if (txtDisplay.Text == "-0" && button.Text != "0")
                        txtDisplay.Text = "-" + button.Text;
                    else
                        txtDisplay.Text += button.Text;
                }
            }
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            // Если была операция после равно, сбрасываем флаг сброса
            _shouldResetOnNextInput = false;

            Button button = (Button)sender;
            string newOperation = button.Text;

            // Если есть сохраненный результат и начат новый ввод
            if (_isNewInput && _expressionParts.Count == 1 && !_operationJustEntered)
            {
                // Добавляем операцию к сохраненному результату
                _expressionParts.Add(newOperation);
                UpdateHistoryLabel();
                _operationJustEntered = true;
                return;
            }

            // Обработка отрицательного числа
            if (newOperation == "-" && (_isNewInput || _operationJustEntered || _expressionParts.Count == 0))
            {
                // Если это первый ввод или после операции, то это отрицательное число
                if (_isNewInput || _operationJustEntered)
                {
                    _isNegativeInput = true;
                    txtDisplay.Text = "-";
                    _isNewInput = false;
                    _operationJustEntered = false;
                    return;
                }
            }

            // Если это операция (не отрицательное число)
            if (!_isNewInput)
            {
                _expressionParts.Add(txtDisplay.Text);
                _expressionParts.Add(newOperation);
                UpdateHistoryLabel();
                _isNewInput = true;
                _isDecimalEntered = false;
                _operationJustEntered = true;
                _isNegativeInput = false; // Сбрасываем флаг отрицательного числа после операции
            }
            else if (_expressionParts.Count > 0)
            {
                // Заменяем последнюю операцию, только если это не ввод отрицательного числа
                if (!(_expressionParts.Last() == "-" && newOperation == "-"))
                {
                    _expressionParts[_expressionParts.Count - 1] = newOperation;
                    UpdateHistoryLabel();
                    _operationJustEntered = true;
                    _isNegativeInput = false;
                }
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (_expressionParts.Count == 0) return;

            if (!_isNewInput)
            {
                _expressionParts.Add(txtDisplay.Text);
            }

            UpdateHistoryLabel();

            try
            {
                _currentValue = EvaluateExpression();
                DisplayCurrentValue();

                // Сохраняем результат для возможных продолжений вычислений
                _expressionParts.Clear();
                _expressionParts.Add(_currentValue.ToString(_culture));
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return;
            }

            // Обновляем историю без "="
            lblHistory.Text = lblHistory.Text.Replace("=", "").Trim();

            _isNewInput = true;
            _isDecimalEntered = false;
            _operationJustEntered = false;
            _shouldResetOnNextInput = true;
        }

        private decimal EvaluateExpression()
        {
            List<string> processedParts = new List<string>(_expressionParts);

            for (int i = 1; i < processedParts.Count; i += 2)
            {
                string op = processedParts[i];
                if (op == "×" || op == "÷")
                {
                    decimal left = decimal.Parse(processedParts[i - 1], _culture);
                    decimal right = decimal.Parse(processedParts[i + 1], _culture);
                    decimal result = 0;

                    if (op == "×")
                        result = left * right;
                    else if (op == "÷")
                    {
                        if (right == 0)
                            throw new DivideByZeroException("Деление на ноль невозможно!");
                        result = left / right;
                    }

                    // Заменяем три элемента (left, op, right) на результат
                    processedParts[i - 1] = result.ToString(_culture);
                    processedParts.RemoveRange(i, 2);
                    i -= 2; // Возвращаемся назад, так как массив изменился
                }
            }

            decimal total = decimal.Parse(processedParts[0], _culture);

            for (int i = 1; i < processedParts.Count; i += 2)
            {
                string op = processedParts[i];
                decimal num = decimal.Parse(processedParts[i + 1], _culture);

                if (op == "+")
                    total += num;
                else if (op == "-")
                    total -= num;
            }

            return total;
        }

        private void UpdateHistoryLabel()
        {
            lblHistory.Text = string.Join(" ", _expressionParts);
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            _operationJustEntered = false;
            // Если есть сохраненный результат и начат новый ввод
            if (_isNewInput && _expressionParts.Count == 1)
            {
                // Начинаем новое число с точки
                txtDisplay.Text = "0.";
                _isNewInput = false;
                _isDecimalEntered = true;
                // Очищаем сохраненный результат, так как начинаем новое число
                _expressionParts.Clear();
                return;
            }
            if (_isNewInput)
            {
                txtDisplay.Text = _isNegativeInput ? "-0." : "0.";
                _isNewInput = false;
                _isDecimalEntered = true;
                _isNegativeInput = false;
            }
            else if (!_isDecimalEntered)
            {
                txtDisplay.Text += ".";
                _isDecimalEntered = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblHistory.Text = "";
            _currentValue = 0;
            _expressionParts.Clear();
            _isNewInput = true;
            _isDecimalEntered = false;
            _isNegativeInput = false;
            _operationJustEntered = false;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            _operationJustEntered = false;
            if (!_isNewInput && txtDisplay.Text.Length > 0)
            {
                if (txtDisplay.Text.EndsWith("."))
                {
                    _isDecimalEntered = false;
                }

                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);

                if (txtDisplay.Text.Length == 0 || txtDisplay.Text == "-")
                {
                    txtDisplay.Text = "0";
                    _isNewInput = true;
                    _isNegativeInput = false;
                }
            }
        }

        private void DisplayCurrentValue()
        {
            string formatted;
            if (_currentValue == decimal.Floor(_currentValue) && Math.Abs(_currentValue) < 1e16m)
            {
                formatted = _currentValue.ToString("0", _culture);
            }
            else
            {
                formatted = _currentValue.ToString("G29", _culture);
            }
            txtDisplay.Text = formatted.Replace(",", ".");
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ResetCalculator();
        }

        private void ResetCalculator()
        {
            txtDisplay.Text = "0";
            lblHistory.Text = "";
            _currentValue = 0;
            _expressionParts.Clear();
            _isNewInput = true;
            _isDecimalEntered = false;
            _isNegativeInput = false;
            _operationJustEntered = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если следующая цифра должна сбросить калькулятор
            if (_shouldResetOnNextInput && char.IsDigit(e.KeyChar))
            {
                ResetCalculator();
                _shouldResetOnNextInput = false;
            }

            switch (e.KeyChar)
            {
                case '0': btn0.PerformClick(); break;
                case '1': btn1.PerformClick(); break;
                case '2': btn2.PerformClick(); break;
                case '3': btn3.PerformClick(); break;
                case '4': btn4.PerformClick(); break;
                case '5': btn5.PerformClick(); break;
                case '6': btn6.PerformClick(); break;
                case '7': btn7.PerformClick(); break;
                case '8': btn8.PerformClick(); break;
                case '9': btn9.PerformClick(); break;
                case '.': case ',': btnDecimal.PerformClick(); break;
                case '+': btnAdd.PerformClick(); break;
                case '-': btnSubtract.PerformClick(); break;
                case '*': btnMultiply.PerformClick(); break;
                case '/': btnDivide.PerformClick(); break;
                case '=': case (char)13: btnEquals.PerformClick(); break;
                case (char)8: btnBackspace.PerformClick(); break;
                case (char)27: btnClear.PerformClick(); break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            txtDisplay.Text = "0";
            txtDisplay.ReadOnly = true;
            txtDisplay.TabStop = false;
        }
    }
}