using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace ListViewWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

    /*
     * TO DO:
     * - EXPORT do Excela
     * - zapis do pliku aby później go wczytać ( przywrócenie wcześniejszej sesji )
     */

    public partial class MainWindow : Window
    {
        
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        //public ObservableCollection<ListView> lv = new ObservableCollection<ListView>();
        
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(close_App);
            
            /*lv.Add(new ListView("z", 2));
            lv.Add(new ListView("a", 3));
            lv.Add(new ListView("c", 1));
            lv.Add(new ListView("g", 33));
            lv.Add(new ListView("x", 26));
            listView.ItemsSource = lv;*/
            //listView.ItemsSource = lv;
            /*listView.Items.Add(new ListView("b", 1));
            listView.Items.Add(new ListView("a", 2));
            listView.Items.Add(new ListView("c", 3));
            listView.Items.Add(new ListView("d", 4));
            listView.Items.Add(new ListView("e", 5));
            listView.Items.Add(new ListView("f", 6));*/
            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTheBox() == true)
            {
                listView.Items.Add(new ListView(textBox1.Text, Convert.ToInt32(textBox2.Text)));
                //lv.Add(new ListView(textBox1.Text, Convert.ToInt32(textBox2.Text)));
                listView.SelectedIndex = listView.Items.Count - 1;
                
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private bool CheckTheBox()
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("You must fill in the fields (Name and Age) to insert an item", "Adding Item...");
                return false;
            }

            return true;
        }

        /*private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            listView.Items.Remove(listView.SelectedItem);
        }*/

        private void removeAllItems_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must to select the fields, which do you want to delete", "Deleting...");
            }
            else
            {
                while (listView.SelectedItems.Count > 0)
                {
                    listView.Items.Remove(listView.SelectedItems[0]);
                }
            }
        }

        private void close_App(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void close_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void selectAllItems_ListView(object sender, RoutedEventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0)
            {
                for (int i = 0; i < this.listView.SelectedItems.Count; i++)
                {
                    this.listView.SelectedIndex = -1;
                }
            }
            else
            {
                listView.SelectAll();
            }
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader; //Pobiera nagłówek np. Name, Age
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding) // headerClicked.Role = Normal != Padding
                {
                    if (headerClicked != _lastHeaderClicked) // _lastHeaderClicked = null
                    {
                        direction = ListSortDirection.Ascending; //Asc
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Column.Header as string;
                    Sort(header, direction);

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        private void Sort(string sortBy, ListSortDirection direction)
        {
            /*ICollectionView dataView = CollectionViewSource.GetDefaultView(listView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();*/

            listView.Items.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            listView.Items.SortDescriptions.Add(sd);
            listView.Items.Refresh();
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            /*Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            */
            string nameFile = DateTime.Now.Date.ToString("dd-MM-yyyy");
            string filePath = @"C:\" + nameFile + ".csv";
            string delimeter = ";";
            
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1; i++)
            {
                sb.AppendLine(string.Join(delimeter, "ID" + ";" + "Name" + ";" + "Age" + ";" + "Date Of Birth" + ";" + "Created"));
            }
            
            for (int index = 0; index < listView.Items.Count; index++ )
            {
                ListView lv = (((ListView)listView.Items[index]));
                //sb.AppendLine(string.Join(delimeter, listView.Items[index].ToString()));
                sb.AppendLine(string.Join(delimeter, lv.ID.ToString() + ";" + lv.Name + ";" + lv.Age.ToString() + ";" + lv.DateOfBirth.ToString() + ";" + lv.Created.ToString() ));    
            }

            if(File.Exists(filePath))
            {
                string messageBoxText = "File exist on " + filePath + "\nDo you want to override this file?";
                string title = "File Exist";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult m = MessageBox.Show(messageBoxText, title, button, icon);

                switch(m)
                {
                    case MessageBoxResult.Yes:
                        File.WriteAllText(filePath, sb.ToString(), UTF8Encoding.UTF8);
                        break;

                    case MessageBoxResult.No:
                        break;
                }  
            }
            else
            {
                File.WriteAllText(filePath, sb.ToString(), UTF8Encoding.UTF8);
                MessageBox.Show("Save to " + filePath, "Quick Save");
            }            
        }

        private void ClearList(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
        }

        private void AddItemInWindow(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItem = new AddItemWindow();
            this.Hide();
            addItem.Show();
            addItem.main = this; //Przesłanie zawartości (main. z listy) do Okna - AddItemWindow
        }

        private void SaveProject(object sender, RoutedEventArgs e)
        {
            // Utwórz folder w tej lokalizacji, w której uruchamiasz plik.exe
            var currentPah = System.IO.Directory.GetCurrentDirectory();
            string folderName = "Save";
            var pathWithFolder = System.IO.Path.Combine(currentPah, folderName);
            
            //Process.Start(currentPah);   otwiera folder z podaną lokalizacją

            // do nowo utworzonego folderu Save dodaj plik który będzie przechowywać sesje
            string fileName = "save.txt";
            var pathWithFile = System.IO.Path.Combine(pathWithFolder, fileName);
            
            string text = "to jest zwykły tekst";

            if (Directory.Exists(pathWithFolder))
            {
                if(File.Exists(pathWithFile))
                {
                    
                    //System.IO.FileStream file = System.IO.File.Create(pathWithFile);
                    Serialize(listView);
                    /*XmlSerializer serializer = new XmlSerializer(typeof(ListView));
                    FileStream fs = null;
                    try
                    {
                        for (int i = 0; i < listView.Items.Count; i++ )
                        {
                            fs = new FileStream(@"C:\Users\Lukii\Documents\Visual Studio 2013\Projects\ListViewWPF\ListViewWPF\bin\Debug\Save\save.xml", FileMode.Create);
                            serializer.Serialize(fs, listView.Items[i]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (fs != null)
                            fs.Close();
                            fs.Dispose();
                    }*/
                    /*
                    using (FileStream stream = File.OpenWrite(pathWithFile))
                    {
                        serializer.Serialize(stream, listView.Items);
                    }*/

                    //Serialize(lv);

                    /*System.IO.StreamWriter sw = new StreamWriter(file);

                    for (int i = 0; i < listView.Items.Count; i++ )
                    {
                        sw.WriteLine(listView.Items[i]);
                    }

                    //sw.WriteLine(text);
                    sw.Close();
                     */
                }
                else
                {
                    System.IO.FileStream file = System.IO.File.Create(pathWithFile);
                    System.IO.StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine(text);
                    sw.Close();
                    //System.IO.File.WriteAllText(pathWithFile, text);
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(pathWithFolder);
                System.IO.FileStream file = System.IO.File.Create(pathWithFile);
                System.IO.StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(text);
                sw.Close();
            }
        }

        private void Serialize(System.Windows.Controls.ListView lv)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ListView));
            XmlSerializerNamespaces serializer_namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            FileStream fs = null;
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            serializer_namespaces.Add(string.Empty, string.Empty);
            
            try
            {
                fs = new FileStream(@"C:\Users\Lukii\Documents\Visual Studio 2013\Projects\ListViewWPF\ListViewWPF\bin\Debug\Save\save.xml", FileMode.Create);
                XmlWriter xmlW = XmlWriter.Create(fs, settings);
                xmlW.WriteStartDocument();
                //XmlWriter xmlW = XmlWriter.Create(@"C:\Users\Lukii\Documents\Visual Studio 2013\Projects\ListViewWPF\ListViewWPF\bin\Debug\Save\save.xml", settings);
                for (int i = 0; i < lv.Items.Count; i++)
                {
                   
                        serializer.Serialize(xmlW, lv.Items[i], serializer_namespaces);
 
                }
                xmlW.WriteEndElement();
                xmlW.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                    //xmlW.Close();
                    
            }
        }
    }
}