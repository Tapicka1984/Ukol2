using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ukol2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty)
            {
                MessageBox.Show("prázdný text box, hledání nebude možné, prosím zadejte někoho");
            }
            else
            {
                try
                {
                    listBox1.Items.Clear();
                    StreamReader ctenar = new StreamReader("knihy.txt");
                    while(!ctenar.EndOfStream)
                    {
                        string line = ctenar.ReadLine();
                        listBox1.Items.Add(line);
                    }
                    ctenar.Close();
                    bool zobraz = true;

                    foreach (string line in listBox1.Items)
                    {
                        string[] pole = line.Split(';');
                        if ((pole[1] == textBox1.Text)&&(zobraz == true))
                        {
                            MessageBox.Show("tento autor:" + pole[1] + "\nnapsal:" + pole[0]);
                            zobraz = false;
                        }
                        DateTime rok = new DateTime();
                        rok = DateTime.Parse(pole[4]);
                        if (rok.Year > 1950)
                        {
                            StreamWriter zapis = new StreamWriter("1950+.txt", true);
                            zapis.WriteLine(line);
                            zapis.Close();
                        }
                        else
                        {
                            StreamWriter zapis2 = new StreamWriter("1950-.txt", true);
                            zapis2.WriteLine(line);
                            zapis2.Close();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("problemek");
                }
            }
        }
    }
}
