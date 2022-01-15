using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;
        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
            sum.ValueChanged += correct_Value_Sum;
            difference.ValueChanged+= correct_Value_Diff;
            product.ValueChanged += correct_Value_Prod;
            quotient.ValueChanged += correct_Value_Quo;
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - subtrahend == difference.Value) && (multiplicand * multiplier == product.Value)
        && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\windows\media\Ring06.wav");
                player.Play();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if(timeLeft > 0)
            {
                if(timeLeft<=5) timeLabel.BackColor = Color.Red;
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\windows\media\beep.wav");
                player.Play();
                timeLabel.BackColor = Color.Empty;
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
           
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }


        private void correct_Value_Sum(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if ((answerBox != null)&&answerBox.Value==addend1+addend2)
            {
                // System.Media.SystemSounds.Beep.Play();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\windows\media\tada.wav");
                player.Play();
            }
        }

        private void correct_Value_Diff(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if ((answerBox != null) && answerBox.Value == minuend - subtrahend)
            {
                // System.Media.SystemSounds.Beep.Play();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\windows\media\tada.wav");
                player.Play();
            }
        }

        private void correct_Value_Prod(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if ((answerBox != null) && answerBox.Value == multiplicand * multiplier)
            {
                // System.Media.SystemSounds.Beep.Play();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\windows\media\tada.wav");
                player.Play();
            }
        }

        private void correct_Value_Quo(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if ((answerBox != null) && answerBox.Value == dividend / divisor)
            {
                // System.Media.SystemSounds.Beep.Play();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\windows\media\tada.wav");
                player.Play();
            }
        }
    }
}
