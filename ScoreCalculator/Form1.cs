//Behrooz Kazemi, and Mohammad Jokar-Konavi
//May 18, 2021
//Extra 8-1 Display a test scores array 


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The array is declared.
        int[] scoresArray = new int[10];
        int count = 0;


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    int score = Convert.ToInt32(txtScore.Text);

                    //The array gets the scores for each count number.
                    scoresArray[count] = score;
                    count += 1;

                    // The total variable changed to a local variable.
                    int total = 0;

                    // A foreach loop is added.
                    foreach (int i in scoresArray)
                    {
                        total += i;
                    }
                    int average = total / count;

                    txtScoreTotal.Text = total.ToString();
                    txtScoreCount.Text = count.ToString();
                    txtAverage.Text = average.ToString();

                    txtScore.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                ex.GetType().ToString() + "\n" +
                ex.StackTrace, "Exception");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            // The current array is replaced with an empty array.
            scoresArray = new int[10]; 
            count = 0;

            txtScore.Text = "";
            txtScoreTotal.Text = "";
            txtScoreCount.Text = "";
            txtAverage.Text = "";

            txtScore.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsValidData()
        {
            return
                // Validate the Score text box
                IsPresent(txtScore, "Score") &&
                IsInt32(txtScore, "Score") &&
                IsWithinRange(txtScore, "Score", 01, 100);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a valid integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name,
            decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min +
                    " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }


        //The new method for the Display button. 
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string allScores = "";

            //The array is sorted.
            Array.Sort(scoresArray);

            //This loop shows all the scores in a message box.
            foreach (int i in scoresArray) 
            {
                if (i != 0)
                {
                    allScores += i.ToString() + "\n";
                }
            }
                
            MessageBox.Show(allScores, "Sorted Scores:");
            txtScore.Focus();
        }
    }
}
