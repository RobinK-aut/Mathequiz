using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mathequiz
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
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 100);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            Differenz.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            Produkt.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            Quotient.Value = 0;


            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            Timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                Timer1.Stop();
                MessageBox.Show("Alles Richtig. Toll gemacht!",
                                "Glückwunsch!");
                startButton.Enabled = true;
            }
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " Sekunden";
                if (timeLeft <= 10 && timeLeft > 5)
                {
                    timeLabel.BackColor = Color.Yellow;
                }
                else if (timeLeft <= 5 && timeLeft > 0)
                {
                    timeLabel.BackColor = Color.Red;
                    timeLabel.ForeColor = Color.White;
                }

            }
            else
            {
                Timer1.Stop();
                timeLabel.Text = "Zeit vorbei!";
                MessageBox.Show("Du hast es leider nicht in der Zeit geschafft. Versuchs nochmal.", "Sorry");
                sum.Value = addend1 + addend2;
                Differenz.Value = minuend - subtrahend;
                Produkt.Value = multiplicand * multiplier;
                Quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                timeLabel.BackColor = Color.White;
                timeLabel.ForeColor = Color.Black;
            }
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == Differenz.Value)
                && (multiplicand * multiplier == Produkt.Value)
                && (dividend / divisor == Quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
