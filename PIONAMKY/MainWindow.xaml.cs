using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       





        string path = "";
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        // Otevření souboru
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog()
            {
                Filter = "txt soubory (*.txt)|*.txt",
                Title = "Otevřít TXT soubor"
            };

            if (OD.ShowDialog() == true)
            {
                path = OD.FileName;
                WriteBTN.IsEnabled = true;
                precist(path);
            }
        }
        //načíst obsah
        private void precist(string path)
        {
            TextVystup.Text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string radek;
                while ((radek = sr.ReadLine()) != null)
                {
                    TextVystup.Text += radek + "\n";
                }
            }
        }

        // Zápis & uložení do souboru
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string vstup = TextVstup.Text;
            string cas = DateTime.Now.ToString("dd/mm/yyyy  -  HH:mm:ss");

            if (TextVstup.Text == "")
            {
                MessageBox.Show("Zadejte Text");
            }
            else
            {
                if (TextVystup.Text == "")
                {
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.Write($"{vstup}\n {cas}");
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.Write($"\n {vstup}\n {cas}");
                    }
                }

                TextVstup.Text = "";
                precist(path);
            }
           
        }

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
              
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("");
                }
                
                TextVystup.Text = ""; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"neni co mazat", "Chyba");
            }
        }
    }
}