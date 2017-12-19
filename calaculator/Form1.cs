using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public double num1, num2, tempresult, a;
        public string Operator;
        public Stack st = new Stack();
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            text_display.Text += "7";
        }

        private void btn_backspace_Click(object sender, EventArgs e)
        {
            try
            {
                text_display.Text = text_display.Text.Substring(0, text_display.Text.Length - 1);
            }
            catch (Exception)
            {
                MessageBox.Show("已经为空了，无法退格了", "错误", MessageBoxButtons.OK);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            text_display.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            text_display.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            text_display.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            text_display.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            text_display.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            text_display.Text += "6";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            text_display.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            text_display.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            text_display.Text += "0";
        }

        private void btn_point_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_display.Text))
                text_display.Text += "0.";
            else if (!text_display.Text.Contains("."))
                text_display.Text += ".";
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            //try
            //{
                st.Push(text_display.Text);
                if (st.Count >= 3)
                {
                    num1 = Convert.ToDouble(st.Pop());
                    Operator = Convert.ToString(st.Pop());
                    num2 = Convert.ToDouble(st.Pop());
                    //tempresult = num1 + num2;
                    //st.Push(tempresult);
                    if (Operator == "+")
                    {
                        tempresult = num1 + num2;
                        //st.Push(tempresult);
                    }
                    else if (Operator == "-")
                    {
                        tempresult = num2 - num1;
                        ///st.Push(tempresult);
                    }
                    else if (Operator == "*")
                    {
                        tempresult = num1 * num2;
                        //st.Push(tempresult);
                    }
                    else if (Operator == "/")
                    {
                        tempresult = num2 / num1;
                        //st.Push(tempresult);
                    }
                    st.Push(tempresult);
                    text_display.Text = tempresult.ToString();
                }
                st.Push("+");
                text_display.Text = "";

            }
            //catch (Exception)
            //{
              //  MessageBox.Show("先输入再计算", "错误", MessageBoxButtons.OK);
                //text_display.Text = "";

            //}
        

        private void btn_minus_Click(object sender, EventArgs e)
        {
            try
            {
                st.Push(text_display.Text);
                if (st.Count >= 3)
                {
                    num1 = Convert.ToDouble(st.Pop());
                    Operator = Convert.ToString(st.Pop());
                    num2 = Convert.ToDouble(st.Pop());
                    if (Operator == "+")
                    {
                        tempresult = num1 + num2;
                        st.Push(tempresult);
                    }
                    else if (Operator == "-")
                    {
                        tempresult = num2 - num1;
                        st.Push(tempresult);
                    }
                    else if (Operator == "*")
                    {
                        tempresult = num1 * num2;
                        st.Push(tempresult);
                    }
                    else if (Operator == "/")
                    {
                        tempresult = num2 / num1;
                        st.Push(tempresult);
                    }
                    text_display.Text = tempresult.ToString();
                }
                st.Push("-");
                text_display.Text= "";
            }
            catch (Exception)
            {
                MessageBox.Show("先输入再计算", "错误", MessageBoxButtons.OK);
                //text_display.Text = "";

            }
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            try
            {
                st.Push(text_display.Text);
                if (st.Count >= 3)
                {
                    num1 = Convert.ToDouble(st.Pop());
                    Operator = Convert.ToString(st.Pop());
                    num2 = Convert.ToDouble(st.Pop());
                    if (Operator == "+")
                    {
                        tempresult = num1 + num2;
                        st.Push(tempresult);
                    }
                    else if (Operator == "-")
                    {
                        tempresult = num2 - num1;
                        st.Push(tempresult);
                    }
                    else if (Operator == "*")
                    {
                        tempresult = num1 * num2;
                        st.Push(tempresult);
                    }
                    else if (Operator == "/")
                    {
                        tempresult = num2 / num1;
                        st.Push(tempresult);
                    }
                    text_display.Text = tempresult.ToString();
                }
                st.Push("*");
                text_display.Text = "";

            }
            catch (Exception)
            {
                MessageBox.Show("先输入再计算", "错误", MessageBoxButtons.OK);
                //text_display.Text = "";

            }
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            try
            {
                st.Push(text_display.Text);
                if (st.Count >= 3)
                {
                    num1 = Convert.ToDouble(st.Pop());
                    Operator = Convert.ToString(st.Pop());
                    num2 = Convert.ToDouble(st.Pop());
                    if (Operator == "+")
                    {
                        tempresult = num1 + num2;
                        st.Push(tempresult);
                    }
                    else if (Operator == "-")
                    {
                        tempresult = num2 - num1;
                        st.Push(tempresult);
                    }
                    else if (Operator == "*")
                    {
                        tempresult = num1 * num2;
                        st.Push(tempresult);
                    }
                    else if (Operator == "/")
                    {
                        tempresult = num2 / num1;
                        st.Push(tempresult);
                    }
                    text_display.Text = tempresult.ToString();
                }
                st.Push("/");
                text_display.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("先输入再计算", "错误", MessageBoxButtons.OK);
                //text_disp = "";

            }
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            try
            {
                st.Push(text_display.Text);
                if (st.Count >= 3)
                {
                    num1 = Convert.ToDouble(st.Pop());
                    Operator = Convert.ToString(st.Pop());
                    num2 = Convert.ToDouble(st.Pop());
                    if (Operator == "+")
                    {
                        tempresult = num1 + num2;
                        //st.Push(tempresult);
                    }
                    else if (Operator == "-")
                    {
                        tempresult = num2 - num1;
                        //st.Push(tempresult);
                    }
                    else if (Operator == "*")
                    {
                        tempresult = num1 * num2;
                       // st.Push(tempresult);
                    }
                    else if (Operator == "/")
                    {
                        tempresult = num2 / num1;
                        //st.Push(tempresult);
                    }
                    text_display.Text = tempresult.ToString();
                }
                text_display.Text = tempresult.ToString();
                st.Clear();

            }
            catch (Exception)
            {
                MessageBox.Show("先输入再计算", "错误", MessageBoxButtons.OK);

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            text_display.Text = "";
            st.Clear();
        }
    }
}