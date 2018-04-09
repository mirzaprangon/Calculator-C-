using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator_2
{
    public partial class Form1 : Form
    {
        string operator_sign,previous_sign;
        Double value_1 = 0, checker = 0;
        Double fact_result = 1,fact_no,percent_no,percent_result;
        int again_checker = 1;//variables declaration
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button_Click(object sender, EventArgs e)//taking input from buttons
        {
            Button b = (Button)sender;
            //come here for correction
            if(checker==1)
            {
                richTextBox1.Clear();
                checker = 0;
            }
            richTextBox1.Text += b.Text;
        }
        private void operator_click(object sender, EventArgs e)//taking operators
        {
            Button b = (Button)sender;
            operator_sign = b.Text;
            if (again_checker == 1)
            {
                value_1 = Double.Parse(richTextBox1.Text);//come back here(solved)
                label1.Text = value_1 + " " + operator_sign;
                previous_sign = operator_sign;
            }
            
            again_checker = again_checker + 1;
            if (again_checker > 2)//trying to operate again and again
            {
                if (previous_sign == "+")
                {
                    value_1 = value_1 + Double.Parse(richTextBox1.Text);
                    label1.Text = value_1 + " " + operator_sign;
                }
                if (previous_sign == "-")
                {
                    value_1 = value_1 - Double.Parse(richTextBox1.Text);
                    label1.Text = value_1 + " " + operator_sign;
                }
                if (previous_sign == "*")
                {
                    value_1 = value_1 * Double.Parse(richTextBox1.Text);
                    label1.Text = value_1 + " " + operator_sign;
                }
                if (previous_sign == "/")
                {
                    value_1 = value_1 / Double.Parse(richTextBox1.Text);
                    label1.Text = value_1 + " " + operator_sign;
                }
                previous_sign = operator_sign;   //very important declaration
            }//end operating again and again
            richTextBox1.Clear();
        }

        private void button16_Click(object sender, EventArgs e)//taking = operator
        {
            label1.Text = "";
            again_checker = 1;
            if(operator_sign=="+")
            {
                richTextBox1.Text = (Double.Parse(richTextBox1.Text) + value_1).ToString();
                checker = 1;
            }
            if (operator_sign == "-")
            {
                richTextBox1.Text = (value_1-Double.Parse(richTextBox1.Text)).ToString();
                checker = 1;
            }
            if (operator_sign == "*")
            {
                richTextBox1.Text = (Double.Parse(richTextBox1.Text) * value_1).ToString();
                checker = 1;
            }
            if (operator_sign == "/")
            {
                richTextBox1.Text = (value_1/Double.Parse(richTextBox1.Text)).ToString();
                checker = 1;
            }
            if(operator_sign==button18.Text)//= operation on root...
            {
                richTextBox1.Text = (Math.Sqrt(Double.Parse(richTextBox1.Text))).ToString();
                checker = 1;
            }
            if (operator_sign == button19.Text)//= operation on factorial...
            {
                fact_result = fact_no;            //write here the factorial function
                while(fact_no>0)
                {
                   
                    fact_result = fact_result * (fact_no - 1);
                    fact_no = fact_no - 1;
                    if (fact_no == 1)
                        break;
                }
                richTextBox1.Text = fact_result.ToString();
                fact_result=1;
                checker = 1;
            }
            if (operator_sign == button20.Text)//= operation on sin...
            {
                Double radian = (((Math.PI) * Double.Parse(richTextBox1.Text)) / 180);
                richTextBox1.Text = Math.Sin(radian).ToString();
                checker = 1;
            }
            if (operator_sign == button21.Text)//= operation on cos...
            {
                Double radian = (((Math.PI) * Double.Parse(richTextBox1.Text)) / 180);
                if (richTextBox1.Text != "90")
                richTextBox1.Text = Math.Cos(radian).ToString();
                if (richTextBox1.Text == "90")
                    richTextBox1.Text = "0";
                checker = 1;
            }
            if (operator_sign == button22.Text)//= operation on tan...
            {
                Double radian = (((Math.PI) * Double.Parse(richTextBox1.Text)) / 180);
                if (richTextBox1.Text != "90")
                richTextBox1.Text = Math.Tan(radian).ToString();
                if (richTextBox1.Text == "90")
                    richTextBox1.Text = "∞";
                checker = 1;
            }
           
            value_1 = 0;//re initializing!!!!!
        }

        private void button24_Click(object sender, EventArgs e)//clear button
        {
            richTextBox1.Clear();
            value_1 = 0;
            label1.Text = "";
            again_checker = 1;
        }

        private void button18_Click(object sender, EventArgs e)//root operation
        {
            if (checker == 1)
                richTextBox1.Clear();
            label1.Text = button18.Text;
            operator_sign = button18.Text;
        }

        private void button19_Click(object sender, EventArgs e)//factorial operation
        {
            fact_no = Double.Parse(richTextBox1.Text);
            label1.Text = richTextBox1.Text +" " +button19.Text;
            operator_sign = button19.Text;
        }

        private void button20_Click(object sender, EventArgs e)//sin operation
        {
            if (checker == 1)
                richTextBox1.Clear();
            label1.Text = button20.Text;
            operator_sign = button20.Text;
        }

        private void button21_Click(object sender, EventArgs e)//cos operation
        {
            if (checker == 1)
                richTextBox1.Clear();
            label1.Text = button21.Text;
            operator_sign = button21.Text;
        }

        private void button22_Click(object sender, EventArgs e)//tan operation
        {
            if (checker == 1)
                richTextBox1.Clear();
            label1.Text = button22.Text;
            operator_sign = button22.Text;
        }

        private void button17_Click(object sender, EventArgs e)//modulus operator
        {
            if(checker==1)
            {
                richTextBox1.Clear();
                label1.Text = "";
                checker = 0;
                
            }
           percent_no= Double.Parse(richTextBox1.Text);
            label1.Text = value_1 + "*" +percent_no+" "+ button17.Text;
            percent_result = (value_1 * percent_no) / 100;
            richTextBox1.Text=percent_result.ToString();
            checker = 1;
            again_checker = 1;

        }

        private void button23_Click(object sender, EventArgs e) //one by one delete button
        {
            if(richTextBox1.Text!=null)
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1, 1);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)//general method for radio buttons
        {
            RadioButton r = (RadioButton)sender;
            if(r==radioButton1)
            {
                if(radioButton1.Checked)
                {
                    button19.Visible = false;
                    button20.Visible = false;
                    button21.Visible = false;
                    button22.Visible = false;
                }
            }
            if (r == radioButton2)
            {
                if (radioButton2.Checked)
                {
                    button19.Visible = true;
                    button20.Visible = true;
                    button21.Visible = true;
                    button22.Visible = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)//checking radiobutton 1
        {
            radioButton1.Checked = true;
        }

    }
}
