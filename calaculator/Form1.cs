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
        public ArrayList array1 = new ArrayList();
        public ArrayList array2 = new ArrayList();
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
            text_display.Text += "+";
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            text_display.Text += "-";
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            text_display.Text += "*";
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            text_display.Text += "%";
        }

        private void btn_exp_Click(object sender, EventArgs e)
        {
            text_display.Text += "^";
        }

        private void btn_lbracket_Click(object sender, EventArgs e)
        {
            text_display.Text += "(";
        }

        private void btn_rbracket_Click(object sender, EventArgs e)
        {
            text_display.Text += ")";
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            text_display.Text += "/";
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            try
            {
                string str = text_display.Text;
                int clu = 0, num = 0, op = 0;
                split(str);
                for (int i = 0; i < array1.Count; i++)
                {
                    if (array1[i].Equals('('))
                        clu++;
                    else if (array1[i].Equals(')'))
                        clu--;
                    else if ((array1[i].ToString()[0] >= '0' & array1[i].ToString()[0] <= '9') |
                         (array1[i].ToString()[0] == '-' & Convert.ToString(array1[i]).Length > 1))
                        num++;
                    else
                        op++;
                }
                if (!(clu == 0 & num == op + 1))
                    throw new Exception("");
                st.Clear();
                st.Push('#');
                for (int i = 0; i < array1.Count;)
                {
                    if ((array1[i].ToString()[0] >= '0' & array1[i].ToString()[0] <= '9') |
                        (array1[i].ToString()[0] == '-' & Convert.ToString(array1[i]).Length > 1))
                    {
                        array2.Add(array1[i]);
                        i++;//若为数加入链表指针后移
                    }
                    else
                    {
                        if (Icp(array1[i]) > Isp(st.Peek()))
                        {
                            st.Push(array1[i]);//为字符时栈外优先级大于栈时入栈指针后移
                            i++;
                        }
                        else if (Icp(array1[i]) == Isp(st.Peek()))
                        {
                            st.Pop();//当栈内外优先级相等时只有左右括号时出现这种情况舍弃左右括号指针后移
                            i++;
                        }
                        else
                        {
                            array2.Add(st.Peek());//当栈内优先级大于栈外时出栈并添加到链表
                            st.Pop();

                        }

                    }
                }
                while (st.Count > 1)//把栈内遗留的字符出栈并添加到链表
                    array2.Add(st.Pop());
                st.Clear();
                string strx = "";
                for (int i = 0; i < array2.Count; i++)
                {
                    strx = Convert.ToString(array2[i]);
                    if ((strx[0] >= '0' & strx[0] <= '9') | (strx[0] == '-' & strx.Length > 1))
                    {
                        st.Push(Convert.ToDouble(strx));
                    }
                    else if (strx == "+")
                    {
                        double x1 = 0, x2 = 0, x3 = 0;
                        x2 = (double)st.Pop();
                        x1 = (double)st.Pop();
                        x3 = x1 + x2;
                        st.Push(x3);
                    }
                    else if (strx == "-")
                    {
                        double x1 = 0, x2 = 0, x3 = 0;
                        x2 = (double)st.Pop();
                        x1 = (double)st.Pop();
                        x3 = x1 - x2;
                        st.Push(x3);
                    }
                    else if (strx == "*")
                    {
                        double x1 = 0, x2 = 0, x3 = 0;
                        x2 = (double)st.Pop();
                        x1 = (double)st.Pop();
                        x3 = x1 * x2;
                        st.Push(x3);
                    }
                    else if (strx == "/")
                    {
                        double x1 = 0, x2 = 0, x3 = 0;
                        x2 = (double)st.Pop();
                        x1 = (double)st.Pop();
                        x3 = x1 / x2;
                        st.Push(x3);
                    }
                    else if (strx == "^")
                    {
                        double x1 = 0, x2 = 0, x3 = 0;
                        x2 = (double)st.Pop();
                        x1 = (double)st.Pop();
                        x3 = Math.Pow(x1, x2);
                        st.Push(x3);
                    }
                    else if (strx == "%")
                    {
                        double x1 = 0, x2 = 0, x3 = 0;
                        x2 = (double)st.Pop();
                        x1 = (double)st.Pop();
                        x3 = x1 % x2;
                        st.Push(x3);
                    }
                }
                text_display.Text = "";
                text_display.Text =Convert.ToString(st.Pop());
                st.Clear();
                array1.Clear();
                array2.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确后再计算", "错误", MessageBoxButtons.OK);
                array1.Clear();
                array2.Clear();
                st.Clear();
                text_display.Text = "";
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            text_display.Text = "";
            st.Clear();
            array1.Clear();
            array2.Clear();
        }

        private void split(string str)//分离数字和字符
        {
            string numstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' & str[i] <= '9')
                    numstr += str[i];
                else if (str[i] == '.')
                    numstr += str[i];
                else if (str[i] == '(' && str[i + 1] == '-')
                {
                    i++;
                    while (str[i] != ')')
                    {
                        numstr += str[i];
                        i++;
                    }
                }
                else if (numstr.Length != 0)
                {
                    array1.Add(numstr);
                    numstr = "";
                    array1.Add(str[i]);
                }
                else
                    array1.Add(str[i]);
            }
            if (numstr.Length != 0)
            {
                array1.Add(numstr);
                numstr = "";
            }
        }

        private int Isp(Object str)//设置栈内优先级
        {
            if (str.Equals('('))
                return 1;
            else if (str.Equals(')'))
                return 6;
            else if (str.Equals('^') | str.Equals('%') | str.Equals('*') |
                str.Equals('/'))
                return 5;
            else if (str.Equals('+') | str.Equals('-'))
                return 3;
            else
                return 0;
        }

        private int Icp(Object str)//设置栈外优先级
        {
            if (str.Equals('('))
                return 6;
            else if (str.Equals(')'))
                return 1;
            else if (str.Equals('^') | str.Equals('%') | str.Equals('*') |
                str.Equals('/'))
                return 4;
            else if (str.Equals('+') | str.Equals('-'))
                return 2;
            else
                return 0;
        }
    }
}