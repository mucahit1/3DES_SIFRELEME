using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DES_Sifreleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void Kontrol()
        {
            if (textBox2.Text.Length != 24)
            {
              string  key=RandomString(24);
                MessageBox.Show("Türkçe Karakter kullanmadığınızdan ve anahtar uzunluğunuzun 24 bit olduğundan emin olunuz");
                textBox2.Text = key;
                MessageBox.Show("Sizin için rastgele bir anahtar oluşturuldu isterseniz bu anahtarı kullanabilirsiniz");



            }
            else
            {
                try
                {
                    TripleDes tDES = new TripleDes(textBox2.Text);
                    tDES.Sifrele(textBox1.Text);
                    GC.Collect();
                    MessageBox.Show("Dosya basarıyla şifrelendi");
                    //MessageBox.Show("Anahtarınızı Kaydedin");



                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);


                }
            }

        }

        //private void Yazdır()
        //{
        //    select();
        //    string path = textBox3.Text;
        //    if (!File.Exists(path))
        //    {
        //        File.Create(path);
        //        TextWriter tw = new StreamWriter(path);
        //        tw.WriteLine("Anahtarınız:" + textBox3.Text);
        //        tw.Close();
        //    }
        //    else if (File.Exists(path))
        //    {
        //        TextWriter tw = new StreamWriter(path);
        //        tw.WriteLine("Anahtarınız:" + textBox3.Text);
        //        tw.Close();
        //    }





        //}
      
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OD = new OpenFileDialog())

            {

                OD.Title = "Open Image";
                OD.Filter = "All Diles|*";


                if (OD.ShowDialog() == DialogResult.OK)

                {

                    string filepath = OD.FileName;
                    textBox1.Text = filepath;

                    //pictureBox_resimSec.Image = new Bitmap(dlg.FileName);

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Dosya Seçiniz!");
            }
            else
            {
                Kontrol();
                //Yazdır();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {

                MessageBox.Show("Dosya Yolunu Seçiniz");
            }

            else
            {
                try
                {
                    TripleDes tDES = new TripleDes(textBox2.Text);
                    tDES.SifreCoz(textBox1.Text);
                    GC.Collect();
                    MessageBox.Show("Şifreniz Çözüldü");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);


                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/m%C3%BCcahit-bozkurt-36869b241/");
        }
        
        private void CreateRandomData(int lowerRange, int upperRange)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Lutfen bitlerin yazdırılacağı  dosya yolu  ve text dosyasını seçiniz");
            }
            else {
                string filename = textBox1.Text;

                Random r = new Random();
                int number = 0;

                using (StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8))
                {
                    for (int i = 0; i <= 1000000; i++)
                    {
                        number = r.Next(lowerRange, upperRange);

                        writer.Write(number + " ");

                    }
                    writer.Flush();
                    writer.Close();
                    MessageBox.Show("Text Dosyanız Oluşturuldu.Dosya Yolunuz:" + filename);
                }

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateRandomData(0,2);
        }
    }
}

