/*
 * Cows and Bulls (Main Class):
 */

using System.Windows.Forms;

namespace cb
{

    /*
     * UI Controls:
     * title: UI title.
     * input: Input for the user's guess.
     * guesses: User's guesess
     */

    public partial class Form1 : Form
    {   
        Wordlist wl = new Wordlist();
        private string pickedWord;

        public Form1()
        {
            InitializeComponent();
            pickedWord = wl.pickWord();
        }

        //Evaluate:
        private void evaluate(string pickedWord, string guessedWord)
        {
            int i = 0;
            int j = 0;
            int cows = 0;
            int bulls = 0;

            for (i = 0; i < pickedWord.Length; i++)
            {
                for (j = 0; j < guessedWord.Length; j++)
                {
                    if (pickedWord[i] == guessedWord[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            cowlist.AppendText(cows.ToString() + "\n");
            bulllist.AppendText(bulls.ToString() + "\n");

            if (bulls == 4)
            {
                MessageBox.Show("You Win!");
                input.Enabled = false;
            }
        }

        //When the 'Go' button is clicked:
        private void button1_Click(object sender, System.EventArgs e)
        {
            string guessedWord = input.Text;
            guessedWord = guessedWord.ToUpper();

            if (guessedWord.Length != 4)
            {
                input.Text = "";
                return;
            }

            guesses.AppendText(guessedWord + "\n");

            this.evaluate(this.pickedWord, guessedWord);
            input.Text = "";
        }
    }
}