using System;
using System.Collections.Generic;
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
        public Form1()
        {
            InitializeComponent();
        }
        char sign = ' ';
        double calc0 = 0;
        double calc1 = 0;
        double result = 0;
        int countAfterDecimal = 0;
        bool isSecondNumber = false;
        bool isDecimal = false;


        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++) {
                Controls["button" + i].Click += new EventHandler(digitalButton_Click);
            }
            plus.Click += new EventHandler(signButton_Click);
            minus.Click += new EventHandler(signButton_Click);
            multiply.Click += new EventHandler(signButton_Click);
            divide.Click += new EventHandler(signButton_Click);
            dec.Checked = true;
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            if (sender.Equals(plus)) {
                sign = '+';
            }

            if (sender.Equals(minus)) {
                sign = '-';
            }

            if (sender.Equals(multiply)) {
                sign = '*';
            }

            if (sender.Equals(divide)) {
                sign = '/';
            }

            isSecondNumber = true;
            if (result != 0) {
                calc0 = result;
            }
            textBox1.Text = calc0.ToString() + " " + sign + " ";

        }

        private void digitalButton_Click(object sender, EventArgs e)
        {
            int temp = 0;
            result = 0;

            for (int i = 0; i < 10; i++) {
                if (sender.Equals(Controls["button" + i])) {
                    temp = i;
                }
            }

            displayNumber(temp);
        }

        private void floatPoint_Click(object sender, EventArgs e)
        {
            isDecimal = true;
            if (isSecondNumber) {
                textBox1.Text = calc0.ToString() + " " + sign + " " + calc1.ToString() + ", ";
            } else {
                textBox1.Text = calc0.ToString() + ", ";
            }
        }

        private void displayNumber(int value0)
        {
            if (isSecondNumber) {
                if (isDecimal) {
                    countAfterDecimal++;
                    calc1 = calc1 + value0 / (countAfterDecimal * 10);
                } else {
                    calc1 = calc1 * 10 + value0;
                }
                textBox1.Text = calc0.ToString() + " " + sign + " " + calc1.ToString() + " ";
            } else {
                if (isDecimal) {
                    countAfterDecimal++;
                    double temp = (double)(Math.Pow(10, countAfterDecimal));
                    calc0 = calc0 + value0 / temp;
                    Console.WriteLine(temp);
                    Console.WriteLine(value0 / temp);

                }
                else {
                    calc0 = calc0 * 10 + value0;
                }
                textBox1.Text = calc0.ToString() + " ";
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearWithValue(0);
        }

        private void clearWithValue(double value)
        {
            textBox1.Text = value.ToString() + " ";
            isSecondNumber = false;
            isDecimal = false;
            calc0 = 0;
            calc1 = 0;
            countAfterDecimal = 0;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            result = 0;
            isDecimal = false;
            countAfterDecimal = 0;

            switch (sign)
            {
                case '+':
                    {
                        result = calc0 + calc1;
                        clearWithValue(result);
                        break;
                    }
                case '-':
                    {
                        result = calc0 - calc1;
                        clearWithValue(result);
                        break;
                    }
                case '*':
                    {
                        result = calc0 * calc1;
                        clearWithValue(result);
                        break;
                    }
                case '/':
                    {
                        result = calc0 / calc1;
                        clearWithValue(result);
                        break;
                    }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

    }
}
