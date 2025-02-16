/*
Szyfr Cezara
Szyfr Playfaira
Szyfr Vigenere
Szyfr Polibiusza
*/

using System.Text.RegularExpressions;
using System.Xml;

namespace AplikacjiaSzyfrowanie
{
    public partial class Form1 : Form
    {
        int wybranySzyfr = 1;
        int optionToDo = 1;
        String pattern = "[abcdefghijklmnopqrstuvwxyz ]";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doMyAction(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            doMyAction(1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            doMyAction(2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        /*
            FUNKCJIE 
        */

        void doMyAction(int option)
        {
            textBox2.ForeColor = Color.Black;
            String daneDoZakodowania = checkCharacters(textBox1.Text);
            String klucz = checkCharacters(textBox3.Text);

            if (daneDoZakodowania == "")
            {
                textBox2.ForeColor = Color.Red;
                textBox2.Text = "U¿ywaj tylko znaków Alfabetu ³aciñskiego.";
            }
            else
            {

                switch (option)
                {
                    case 0:
                        textBox2.Text = koduj(daneDoZakodowania, wybranySzyfr, klucz);
                        label1.Text = "Wykonano kodowanie.";
                        break;
                    case 1:
                        textBox2.Text = dekoduj(daneDoZakodowania, wybranySzyfr, klucz);
                        label1.Text = "Wykonano dekodowanie.";
                        break;
                    case 2:
                        textBox1.Text = textBox2.Text;
                        textBox2.Text = "";
                        label1.Text = "Wynik przeniesiony do danych wejœciowych.";
                        break;
                    default:
                        break;
                }
            }
        }

        String koduj(String input, int box, string klucz)
        {
            String output = "Coœ posz³o nie tak!";

            switch (box)
            {
                case 1:
                    SzyfrCezara szyfrCezara = new SzyfrCezara();
                    output = szyfrCezara.Koduj(input, klucz);
                    break;
                case 2:
                    SzyfrPlayfaira szyfrPlayfaira = new SzyfrPlayfaira(klucz);
                    output = szyfrPlayfaira.Koduj(input);
                    break;
                case 3:
                    SzyfrVigenere szyfrVigenere = new SzyfrVigenere();
                    output = szyfrVigenere.Koduj(input, klucz);
                    break;
                case 4:
                    SzyfrPolibiusza szyfrPolibiusza = new SzyfrPolibiusza();
                    output = szyfrPolibiusza.Koduj(input);
                    break;
                case 5:
                    break;
                default:
                    break;
            }
            return output;
        }

        String dekoduj(String input, int box, string klucz)
        {
            String output = "Coœ posz³o nie tak!";

            switch (box)
            {
                case 1:
                    SzyfrCezara szyfrCezara = new SzyfrCezara();
                    output = szyfrCezara.Dekoduj(input, klucz);
                    break;
                case 2:
                    SzyfrPlayfaira szyfrPlayfaira = new SzyfrPlayfaira(textBox3.Text);
                    output = szyfrPlayfaira.Dekoduj(input);
                    break;
                case 3:
                    SzyfrVigenere szyfrVigenere = new SzyfrVigenere();
                    output = szyfrVigenere.Dekoduj(input, klucz);
                    break;
                case 4:
                    SzyfrPolibiusza szyfrPolibiusza = new SzyfrPolibiusza();
                    output = szyfrPolibiusza.Dekoduj(input);
                    break;
                case 5:
                    break;
                default:
                    break;
            }
            return output;
        }


        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox currentCheckBox && currentCheckBox.Checked)
            {
                if (currentCheckBox.Name == "cb1")
                {
                    wybranySzyfr = 1;
                }
                else if (currentCheckBox.Name == "cb2")
                {
                    wybranySzyfr = 2;
                }
                else if (currentCheckBox.Name == "cb3")
                {
                    wybranySzyfr = 3;
                }
                else if (currentCheckBox.Name == "cb4")
                {
                    wybranySzyfr = 4;
                }
                else { wybranySzyfr = 1; }

                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox checkBox && checkBox != currentCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }

        string checkCharacters(string message)
        {
            message = message.Trim();
            message = message.ToUpper();

            foreach (char znak in message)
            {
                if (!char.IsLetter(znak))
                {
                    if (znak == ' ')
                    {

                    }
                    else
                    {
                        return "";
                    }
                }
            }
            return message;
        }
    }
}
