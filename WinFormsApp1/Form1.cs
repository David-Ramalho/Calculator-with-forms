using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private bool IsLastCharacterOperator(string text)
        {
            if (text.Length > 0)
            {
                // Get the last character of the text
                char lastCharacter = text[text.Length - 1];

                // Check if the last character is an operator (+, -, *, /)
                return lastCharacter == '+' || lastCharacter == '-' || lastCharacter == '*' || lastCharacter == '/';
            }

            return false;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Check if the TextBox is empty or the last character is an operator
            if (string.IsNullOrEmpty(textBox1.Text) || IsLastCharacterOperator(textBox1.Text))
                return;

            // Append the operator to the TextBox
            textBox1.Text += button.Text;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Clear the TextBox
            textBox1.Text = string.Empty;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            // Use the DataTable.Compute method to evaluate the expression and get the result
            var dataTable = new DataTable();
            try
            {
                var result = dataTable.Compute(textBox1.Text, null);
                textBox1.Text = result.ToString();
            }
            catch (Exception)
            {
                textBox1.Text = "Error";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Wire up the click events for number buttons
            button1.Click += NumberButton_Click;
            button2.Click += NumberButton_Click;
            button3.Click += NumberButton_Click;
            button4.Click += NumberButton_Click;
            button5.Click += NumberButton_Click;
            button6.Click += NumberButton_Click;
            button7.Click += NumberButton_Click;
            button8.Click += NumberButton_Click;
            button9.Click += NumberButton_Click;
            button14.Click += NumberButton_Click;
            button17.Click += NumberButton_Click;

            // Wire up the click events for operator buttons
            button13.Click += OperatorButton_Click;
            button12.Click += OperatorButton_Click;
            button11.Click += OperatorButton_Click;
            button10.Click += OperatorButton_Click;

            // Wire up the click event for the clear button
            button16.Click += ClearButton_Click;

            // Wire up the click event for the equals button
            button15.Click += EqualsButton_Click;
        }

      
    }
}