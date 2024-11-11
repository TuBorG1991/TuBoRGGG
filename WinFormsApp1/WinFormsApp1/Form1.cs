using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e) => AddNumberToDisplay("0");
        private void button1_Click(object sender, EventArgs e) => AddNumberToDisplay("1");
        private void button2_Click(object sender, EventArgs e) => AddNumberToDisplay("2");
        private void button3_Click(object sender, EventArgs e) => AddNumberToDisplay("3");
        private void button4_Click(object sender, EventArgs e) => AddNumberToDisplay("4");
        private void button5_Click(object sender, EventArgs e) => AddNumberToDisplay("5");
        private void button6_Click(object sender, EventArgs e) => AddNumberToDisplay("6");
        private void button7_Click(object sender, EventArgs e) => AddNumberToDisplay("7");
        private void button8_Click(object sender, EventArgs e) => AddNumberToDisplay("8");
        private void button9_Click(object sender, EventArgs e) => AddNumberToDisplay("9");

        private void AddNumberToDisplay(string number)
        {
            if (textBoxDisplay.Text == "0")
                textBoxDisplay.Text = number;
            else
                textBoxDisplay.Text += number;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!textBoxDisplay.Text.Contains(","))
                textBoxDisplay.Text += ",";
        }

        private void AddOperationToDisplay(string operation)
        {
            string lastChar = textBoxDisplay.Text.Length > 0 ? textBoxDisplay.Text[^1].ToString() : string.Empty;

            if (operation == "-" && (textBoxDisplay.Text.Length == 0 || textBoxDisplay.Text == "0"))
            {
                textBoxDisplay.Text = "-";
            }
            else if ("+-*/".Contains(lastChar))
            {
                textBoxDisplay.Text = textBoxDisplay.Text.Remove(textBoxDisplay.Text.Length - 1) + operation;
            }
            else
            {
                textBoxDisplay.Text += operation;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e) => AddOperationToDisplay("+");
        private void buttonSubtract_Click(object sender, EventArgs e) => AddOperationToDisplay("-");
        private void buttonMultiply_Click(object sender, EventArgs e) => AddOperationToDisplay("*");
        private void buttonDivide_Click(object sender, EventArgs e) => AddOperationToDisplay("/");

        private void buttonOpenBracket_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text == "0")
            {
                textBoxDisplay.Text = "(";
            }
            else if (textBoxDisplay.Text.Length == 0 || "+-*/(".Contains(textBoxDisplay.Text[^1].ToString()))
            {
                textBoxDisplay.Text += "(";
            }
        }

        private void buttonCloseBracket_Click(object sender, EventArgs e)
        {
            int openBrackets = textBoxDisplay.Text.Count(c => c == '(');
            int closeBrackets = textBoxDisplay.Text.Count(c => c == ')');

            if (openBrackets > closeBrackets)
            {
                textBoxDisplay.Text += ")";
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = textBoxDisplay.Text.Replace(",", ".");

                if (expression.Contains("Mod"))
                {
                    string[] parts = expression.Split(new[] { "Mod" }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        double leftOperand = Convert.ToDouble(parts[0]);
                        double rightOperand = Convert.ToDouble(parts[1]);
                        double result = leftOperand % rightOperand;
                        textBoxDisplay.Text = result.ToString();
                    }
                    else
                    {
                        throw new Exception("Некорректное выражение для операции Mod!");
                    }
                }
                else if (expression.Contains("^"))
                {
                    string[] parts = expression.Split('^');
                    if (parts.Length == 2)
                    {
                        double baseValue = Convert.ToDouble(parts[0]);
                        double exponent = Convert.ToDouble(parts[1]);
                        double result = Math.Pow(baseValue, exponent);
                        textBoxDisplay.Text = result.ToString();
                    }
                    else
                    {
                        throw new Exception("Некорректное выражение для возведения в степень!");
                    }
                }
                else
                {
                    var table = new DataTable();
                    var result = table.Compute(expression, null);
                    textBoxDisplay.Text = result.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в выражении!");
                textBoxDisplay.Text = "0";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = "0";
        }

        private void buttonLn_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBoxDisplay.Text);

                if (number > 0)
                {
                    double result = Math.Log(number);
                    textBoxDisplay.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Число должно быть больше нуля для вычисления ln!");
                    textBoxDisplay.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в выражении!");
                textBoxDisplay.Text = "0";
            }
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBoxDisplay.Text);

                if (number <= 0)
                {
                    MessageBox.Show("Логарифм можно вычислить только для положительных чисел!");
                    textBoxDisplay.Text = "0";
                }
                else
                {
                    double result = Math.Log10(number);
                    textBoxDisplay.Text = result.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат числа!");
                textBoxDisplay.Text = "0";
            }
        }

        private void button10x_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(textBoxDisplay.Text);
                double result = Math.Pow(10, number);
                textBoxDisplay.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: введено некорректное число!");
                textBoxDisplay.Text = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в вычислениях!");
                textBoxDisplay.Text = "0";
            }
        }

        private void button_x_on_y_Click(object sender, EventArgs e)
        {
            string lastChar = textBoxDisplay.Text[^1].ToString();
            if (!"+-*/^".Contains(lastChar))
            {
                textBoxDisplay.Text += "^";
            }
        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBoxDisplay.Text);

                if (number < 0)
                {
                    MessageBox.Show("Невозможно вычислить квадратный корень из отрицательного числа!");
                    textBoxDisplay.Text = "0";
                }
                else
                {
                    double result = Math.Sqrt(number);
                    textBoxDisplay.Text = result.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат числа!");
                textBoxDisplay.Text = "0";
            }
        }

        private void button_x_to_2_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBoxDisplay.Text);
                double result = Math.Pow(number, 2);
                textBoxDisplay.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат числа!");
                textBoxDisplay.Text = "0";
            }
        }

        private void button_1_x_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBoxDisplay.Text);

                if (number == 0)
                {
                    MessageBox.Show("Деление на ноль невозможно!");
                    textBoxDisplay.Text = "0";
                }
                else
                {
                    double result = 1 / number;
                    textBoxDisplay.Text = result.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат числа!");
                textBoxDisplay.Text = "0";
            }
        }

        private void button_fact_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBoxDisplay.Text);

                if (number < 0)
                {
                    MessageBox.Show("Факториал для отрицательных чисел не существует!");
                    textBoxDisplay.Text = "0";
                }
                else
                {
                    long result = 1;
                    for (int i = 1; i <= number; i++)
                    {
                        result *= i;
                    }

                    textBoxDisplay.Text = result.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат числа!");
                textBoxDisplay.Text = "0";
            }
        }

        private void button_modul_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBoxDisplay.Text);
                double result = Math.Abs(number);
                textBoxDisplay.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат числа!");
                textBoxDisplay.Text = "0";
            }
        }
    }
}
