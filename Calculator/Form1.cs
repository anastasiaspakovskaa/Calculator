using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Operations;


namespace Calculator
{
    public partial class Form1 : Form
    {
        double num1, num2;
        string operation;
        bool operationSet = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void number_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                if (operationSet)
                {
                    operationSet = false;
                    textBox1.Text = "";
                }
                textBox1.Text += clickedButton.Text;

            }
        }

        private void operation_Click(object sender, EventArgs e)
        {
            try
            {
                Button clickedButton = sender as Button;
                if (clickedButton != null)
                {
                    operationSet = true;
                    if (textBox1.Text == "")
                    {
                        throw new Exception("Input is empty");
                    }
                    num1 = Convert.ToDouble(textBox1.Text);
                    operation = clickedButton.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            try
            {
                if (operationSet | textBox1.Text == "")
                {
                    throw new Exception("Input is empty");
                }
                operationSet = true;
                num2 = Convert.ToDouble(textBox1.Text);

                switch (operation)
                {
                    case "+":
                        textBox1.Text = Operations.Operations.Plus(num1, num2).ToString();
                        break;
                    case "-":
                        textBox1.Text = Operations.Operations.Minus(num1, num2).ToString();
                        break;
                    case "*":
                        textBox1.Text = Operations.Operations.Mul(num1, num2).ToString();
                        break;
                    case "/":
                        textBox1.Text = Operations.Operations.Div(num1, num2).ToString();
                        break;
                    default:
                        textBox1.Text = "";
                        break;
                }
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            textBox1.Text = "";
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Calculator. Version 1.0.\nAvailable operations: +, -, *, /.", 
                "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
