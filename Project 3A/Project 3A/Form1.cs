using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_3A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class startwitheight : Exception
        {


            public startwitheight()
            {
                MessageBox.Show("An exception has occured the number cannot start with 8 for the first number");
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {

                double weight = Convert.ToDouble(txtWeight.Text);
                const double convertkg = 0.45;
                double weightkg = weight * convertkg;

                int feet = Convert.ToInt32(txtFeet.Text);
                int inch = Convert.ToInt32(txtInches.Text);
                int heightinch = (feet * 12) + inch;
                const double convertmtr = 0.025;
                double heightmtr = heightinch * convertmtr;
                double heightsqr = Math.Pow(heightmtr, 2);
                string x = txtFeet.Text;
                if (weight > 900)
                {
                    throw new OverflowException();
                };
                if (x.StartsWith("8"))
                {
                    throw new startwitheight();
                }

                double bmi = weightkg / heightsqr;
                string textResult = " ";
                double DivideBy = Convert.ToDouble(txtDivideBy.Text);
                double num = bmi / DivideBy;
                txtAnswer.Text = num.ToString("n2");
                
                if (DivideBy == 0)
                {
                    MessageBox.Show("Divide by zero error. Please enter a number greater than zero");
                }
                if (rbtnFemale.Checked)
                {
                    if (bmi < 18)
                    {
                        textResult = "Underweight";
                    }
                    else if (bmi >= 18 && bmi < 25)
                    {
                        textResult = "Normal";
                    }
                    else if (bmi >= 25 && bmi < 30)
                    {
                        textResult = "Overweight";
                    }
                    else if (bmi >= 30)
                    {
                        textResult = "Obese";
                    }

                }

                else if (rbtnMale.Checked)
                {
                    if (bmi < 19)
                    {
                        textResult = "Underweight";
                    }
                    else if (bmi >= 19 && bmi < 26)
                    {
                        textResult = "Normal";

                    }
                    else if (bmi >= 26 && bmi < 31)
                    {
                        textResult = "Overweight";
                    }
                    else if (bmi >= 31)
                    {
                        textResult = "Obese";
                    }
                }
                txtResult.Text = textResult;
                txtBody.Text = bmi.ToString("n2");


            }
            catch (FormatException)
            {
                MessageBox.Show("Format Error. Please enter values in number only");
               
            }
            catch (OverflowException)
            {
                MessageBox.Show("Overflow error. Please enter Number less then 900");
                
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Divide by zero error. Please enter a number greater than zero");
                
            }
            catch (startwitheight)
            {
                txtFeet.Focus();
            }

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
