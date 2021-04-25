using System;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {

        char sign = ' ';
        double calc0 = 0;
        double calc1 = 0;
        double result = 0;
        int countAfterDecimal = 0;
        bool isSecondNumber = false;
        bool isDecimal = false;
        bool isEndCalculation = false;
        bool signPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Controls["button" + i].Click += new EventHandler(digitalButton_Click);
            plus.Click += new EventHandler(signButton_Click);
            minus.Click += new EventHandler(signButton_Click);
            multiply.Click += new EventHandler(signButton_Click);
            divide.Click += new EventHandler(signButton_Click);
            dec.Checked = true;
        }

        private void digitalButton_Click(object sender, EventArgs e)
        {
            result = 0;
            int current = 0;

            for (int i = 0; i < 10; i++)
            {
                current = sender.Equals(Controls["button" + i]) ? i : current;
            }

            addDigit(current);

            isEndCalculation = false;
        }
        private void signButton_Click(object sender, EventArgs e)
        {
            if (isSecondNumber) calculation();

            sign = sender.Equals(plus) ? '+' :
                   sender.Equals(minus) ? '-' :
                   sender.Equals(multiply) ? '*' : '/';

            calc0 = isEndCalculation ? result : calc0;
            calc1 = 0;
            result = 0;
            countAfterDecimal = 0;
            isDecimal = false;
            isSecondNumber = true;
            isEndCalculation = false;
            signPressed = true;

            display();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearTextBox();
            textBox1.Text = "0 ";
        }

        private void equal_Click(object sender, EventArgs e)
        {
            calculation();
        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void floatPoint_Click(object sender, EventArgs e)
        {
            isDecimal = true;
            display();
        }

        private void addDigit(int digit)
        {
            if (isSecondNumber && isDecimal)
            {
                countAfterDecimal++;
                calc1 = (double)(calc1 + digit / Math.Pow(10, countAfterDecimal));
            }
            else if (isSecondNumber && !isDecimal)
            {
                calc1 = calc1 * 10 + digit;
            }
            else if (!isSecondNumber && isDecimal)
            {
                countAfterDecimal++;
                calc0 = (double)(calc0 + digit / Math.Pow(10, countAfterDecimal));
            }
            else
            {
                calc0 = calc0 * 10 + digit;
            }

            display();
        }
        private void display()
        {
            if (isSecondNumber)
            {
                if (isDecimal && calc1 % 1 == 0)
                {
                    textBox1.Text = calc0.ToString() + " " + sign + " " + calc1.ToString() + ", ";
                }
                else if (signPressed)
                {
                    textBox1.Text = calc0.ToString() + " " + sign + " ";
                }
                else if (isDecimal && countAfterDecimal != 0)
                {
                    textBox1.Text = calc1.ToString();
                    for (int i = 0; i < countAfterDecimal; i++)
                    {
                        textBox1.Text = textBox1.Text + "0";
                    }
                    textBox1.Text = textBox1.Text + " ";
                }
                else
                {
                    textBox1.Text = calc0.ToString() + " " + sign + " " + calc1.ToString() + " ";
                }
            }
            else if (!isSecondNumber)
            {
                if (isDecimal && calc0 % 1 == 0)
                {
                    if (countAfterDecimal != 0)
                    {
                        textBox1.Text = calc0.ToString() + ",";
                        for (int i = 0; i < countAfterDecimal; i++)
                        {
                            textBox1.Text += "0";
                        }
                        textBox1.Text += " ";
                    }
                    else
                    {
                        textBox1.Text = calc0.ToString() + ", ";

                    }
                }
                else
                {
                    textBox1.Text = calc0.ToString() + " ";
                }
            }

            if (isEndCalculation)
            {
                textBox1.Text = result.ToString() + " ";
            }

            signPressed = false;
        }



        private void clearTextBox()
        {
            isSecondNumber = false;
            isDecimal = false;
            calc0 = 0;
            calc1 = 0;
            countAfterDecimal = 0;
        }

        private void calculation()
        {
            result = 0;
            isDecimal = false;
            countAfterDecimal = 0;

            switch (sign)
            {
                case '+':
                    result = calc0 + calc1;
                    clearTextBox();
                    break;
                case '-':
                    result = calc0 - calc1;
                    clearTextBox();
                    break;
                case '*':
                    result = calc0 * calc1;
                    clearTextBox();
                    break;
                case '/':
                    result = calc0 / calc1;
                    clearTextBox();
                    break;
            }

            isEndCalculation = true;
            display();
        }

    }
}
