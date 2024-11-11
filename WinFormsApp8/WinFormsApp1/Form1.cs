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
            if (!textBoxDisplay.Text.Contains("."))
                textBoxDisplay.Text += ".";
        }

        private void AddOperationToDisplay(string operation)
        {
            string lastChar = textBoxDisplay.Text[^1].ToString();
            if ("+-*/".Contains(lastChar))
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

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                var table = new DataTable();
                var result = table.Compute(textBoxDisplay.Text, null);
                textBoxDisplay.Text = result.ToString();
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
    }
}
