using System.Data;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private string currentOperation = "";
        private double firstNumber = 0;
        private bool isSecondNumber = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Кнопки чисел (не изменяем их код)
        private void n_0_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "0";
            else
                pole_vvoda.Text += "0";
        }

        private void n_1_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "1";
            else
                pole_vvoda.Text += "1";
        }

        private void n_2_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "2";
            else
                pole_vvoda.Text += "2";
        }

        private void n_3_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "3";
            else
                pole_vvoda.Text += "3";
        }

        private void n_4_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "4";
            else
                pole_vvoda.Text += "4";
        }

        private void n_5_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "5";
            else
                pole_vvoda.Text += "5";
        }

        private void n_6_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "6";
            else
                pole_vvoda.Text += "6";
        }

        private void n_7_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "7";
            else
                pole_vvoda.Text += "7";
        }

        private void n_8_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "8";
            else
                pole_vvoda.Text += "8";
        }

        private void n_9_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "0" && pole_vvoda.Text != null)
                pole_vvoda.Text = "9";
            else
                pole_vvoda.Text += "9";
        }

        private void n_plus_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "")
                pole_vvoda.Text = "0+";
            else
                pole_vvoda.Text += "+";
        }

        private void n_minus_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "")
                pole_vvoda.Text = "0-";
            else
                pole_vvoda.Text += "-";
        }

        private void n_umnog_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "")
                pole_vvoda.Text = "0*";
            else
                pole_vvoda.Text += "*";
        }

        private void n_delit_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "")
                pole_vvoda.Text = "0/";
            else
                pole_vvoda.Text += "/";
        }

        private void n_tochka_Click(object sender, EventArgs e)
        {
            if (pole_vvoda.Text == "")
                pole_vvoda.Text = "0.";
            else
                pole_vvoda.Text += ".";
        }

        private void n_ravno_Click(object sender, EventArgs e)
        {
            try
            {
                var result = new DataTable().Compute(pole_vvoda.Text, null);
                pole_vvoda.Text = result.ToString();
            }
            catch
            {
                pole_vvoda.Text = "Ошибка";
            }
        }
        private void n_chistka_Click(object sender, EventArgs e)
        {
            pole_vvoda.Text = "";
        }
        private void n_chistka_1_Click(object sender, EventArgs e)
        {
            pole_vvoda.Text = pole_vvoda.Text.Substring(0, pole_vvoda.Text.Length - 1);
        }
    }
}
