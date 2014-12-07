using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace ListViewWPF
{
    /// <summary>
    /// Logika interakcji dla klasy AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public MainWindow main;

        enum Color
        {
            Red = 1,
            Yellow = 2,
            Blue = 3,
            Orange = 4,
            Pink = 5,
            Black = 6,
            Grey = 7,
            Violet = 8,
            LightBlue = 9,
            LightYellow = 10,
            LightPink = 11,
            LightGreen = 12,
            LightCoral = 13,
            LightCyan = 14
        }

        public AddItemWindow()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(OpenBasicWindow);         
        }

        int counter = 0;
        
        private void AddItem(object sender, RoutedEventArgs e)
        {
            if (CheckTheBox() == true)
            {
                main.listView.Items.Add(new ListView(txtBoxAddName.Text, Convert.ToInt32(txtBoxAddAge.Text)));
                //main.lv.Add(new ListView(txtBoxAddAge.Text, Convert.ToInt32(txtBoxAddAge.Text)));
            }

            txtBoxAddName.Text = "";
            txtBoxAddAge.Text = "";

            this.Close();
            main.Show();
        }

        private bool CheckTheBox()
        {
            if (txtBoxAddName.Text.Length == 0 || txtBoxAddAge.Text.Length == 0)
            {
                MessageBox.Show("You must fill in the fields (Name and Age) to insert an item", "Adding Item...");
                return false;
            }

            return true;
        }

        private void Counter(object sender, RoutedEventArgs e)
        {
            counter++;
            CounterLabel.Content = counter;

            
            if(counter % 10 == 0)
            {
                Random gen = new Random();
                int generate_number = gen.Next(1, 15);
                Color color = (Color)generate_number;

                switch (color)
                {
                    case Color.Red:
                        CounterLabel.Foreground = Brushes.Red;
                        break;
                    case Color.Yellow:
                        CounterLabel.Foreground = Brushes.Yellow;
                        break;
                    case Color.Blue:
                        CounterLabel.Foreground = Brushes.Blue;
                        break;
                    case Color.Orange:
                        CounterLabel.Foreground = Brushes.Orange;
                        break;
                    case Color.Pink:
                        CounterLabel.Foreground = Brushes.Pink;
                        break;
                    case Color.Black:
                        CounterLabel.Foreground = Brushes.Black;
                        break;
                    case Color.Grey:
                        CounterLabel.Foreground = Brushes.Gray;
                        break;
                    case Color.Violet:
                        CounterLabel.Foreground = Brushes.Violet;
                        break;
                    case Color.LightBlue:
                        CounterLabel.Foreground = Brushes.LightBlue;
                        break;
                    case Color.LightYellow:
                        CounterLabel.Foreground = Brushes.LightYellow;
                        break;
                    case Color.LightPink:
                        CounterLabel.Foreground = Brushes.LightPink;
                        break;
                    case Color.LightGreen:
                        CounterLabel.Foreground = Brushes.LightGreen;
                        break;
                    case Color.LightCoral:
                        CounterLabel.Foreground = Brushes.LightCoral;
                        break;
                    case Color.LightCyan:
                        CounterLabel.Foreground = Brushes.LightCyan;
                        break;
                    default:
                        MessageBox.Show("Something went wrong");
                        break;
                }
            }
        }

        private void OpenBasicWindow(object sender, CancelEventArgs e)
        {   
            main.Show();
        }
    }
}
