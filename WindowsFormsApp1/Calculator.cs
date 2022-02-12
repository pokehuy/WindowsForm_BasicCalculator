using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Calculator : Form
    {
        public string memo { get; set; }
        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            Jace.CalculationEngine engine = new Jace.CalculationEngine();
            string clickedbutton = ((Button)sender).Text;
            switch (clickedbutton)
            {
                case "C":
                    textBox1.Text = "";
                    break;
                case "sqr":
                    textBox1.Text = "Sqrt(" + textBox1.Text.ToString() + ")";
                    break;
                case "1/x":
                    textBox1.Text = "1/(" + textBox1.Text.ToString() + ")";
                    break;
                case "%":
                    textBox1.Text = textBox1.Text + "/100";
                    break;
                case "+/-":
                    if(textBox1.Text.Substring(0,1).Equals("-"))
                    {
                        textBox1.Text = textBox1.Text.Remove(0,1);
                    } else
                    {
                        textBox1.Text = "-" + textBox1.Text;
                    }
                    break;
                case "CE":
                case "Backspace":
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    break;
                case "MS":
                    memo = textBox1.Text;
                    textBox1.Text = "";
                    break;
                case "M+":
                    memo = engine.Calculate(textBox1.Text.ToString() + "+" + memo).ToString();
                    textBox1.Text = "";
                    break;
                case "MC":
                    memo = "";
                    textBox1.Text = "";
                    break;
                case "MR":
                    textBox1.Text = memo;
                    break;
                case "=":
                    textBox1.Text = engine.Calculate(textBox1.Text.Replace("x", "*")).ToString();
                    break;
                default:
                    textBox1.Text += clickedbutton;
                    break;
            }
        }

    }
}
