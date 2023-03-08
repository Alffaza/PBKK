using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        double num;
        string currNum = "";
        List<string> operations = new List<string>();
        string operationchars = "-+/*";
        string disp = "";
        string ans;
        private void numButton(int n)
        {
            string n_char = n.ToString();
            if ((operations.Count != 0 && operationchars.Contains(operations.Last())) ||( currNum == "0"))
            {
                currNum = n_char;
            } else
            {
                currNum += n_char;
            }
            disp += n_char;
            resultlabel.Text = disp;
        }

        private void opButton(string op)
        {
            operations.Add(currNum);
            if (operationchars.Contains(operations.Last()))
            {
                operations.RemoveAt(operations.Count - 1);
                disp = disp.Substring(0,disp.Length-1);
            }
            operations.Add(op);
            currNum = "";
            disp += op;
            resultlabel.Text = disp;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            numButton(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            numButton(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numButton(3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            numButton(4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            numButton(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numButton(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numButton(7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            numButton(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numButton(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            numButton(0);
        }
        private void button13_Click(object sender, EventArgs e) //result
        {
            operations.Add(currNum);
            double val = Int32.Parse(operations.First());
            operations.RemoveAt(0);
            while (operations.Count > 0)
            {
                string temp_op = operations.First();

                
                operations.RemoveAt(0);
                double temp_val = Int32.Parse(operations.First());
                operations.RemoveAt(0);

                if (temp_op == "+")
                {
                    val += temp_val;
                }
                else if (temp_op == "-")
                {
                    val -= temp_val;
                }
                else if (temp_op == "*")
                {
                    val *= temp_val;
                }
                else if (temp_op == "/")
                {
                    val /= temp_val;
                }
                else
                {
                    break;
                }
                //
                //string temp_op = operations.First();
                //while (! ("+-".Contains(temp_op)))
                //{
                //    operations.RemoveAt(0);
                //    if (temp_op == "*")
                //    {
                //        temp_val *= Int32.Parse(operations.First());
                //    }
                //    if (temp_op == "/")
                //    {
                //        temp_val /= Int32.Parse(operations.First());
                //    }
                //    operations.RemoveAt(0);
                //    temp_op = operations.First();
                //}
                
            }
            resultlabel.Text = val.ToString();
            currNum = "";
            disp = "";
        }
        private void buttonmin_Click(object sender, EventArgs e)
        {
            opButton("-");
        }
        private void buttonplus_Click(object sender, EventArgs e)
        {
        }

        private void buttondiv_Click(object sender, EventArgs e)
        {
            opButton("/");
        }

        private void buttonmul_Click(object sender, EventArgs e)
        {
            opButton("*");
        }

        private void buttonans_Click(object sender, EventArgs e)
        {
            currNum = ans;
        }

        private void buttonplus_Click_1(object sender, EventArgs e)
        {
            opButton("+");
        }
    }
}
