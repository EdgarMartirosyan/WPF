using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Books> p1 = new List<Books>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Books>));
            p1.Add(new Books()
            {
                Genre = "autobiography",
                Publicationdate = 1991,
                ISBN = "1-861003-11-0",
                Title = "The Autobiography of Benjamin Franklin",
                FirstName = "Benjamin",
                LastName = "Franklin",
                Price = 8.99m,
                Name = "",
            });
            p1.Add(new Books()
            {
                Genre = "novel",
                Publicationdate = 1967,
                ISBN = "0-201-63361-2",
                Title = "The Confidence Man",
                FirstName = "Herman",
                LastName = "Melville",
                Price = 11.99m,
                Name = "",
            });
            p1.Add(new Books()
            {
                Genre = "philosophy",
                Publicationdate = 1991,
                ISBN = "1-861001-57-6",
                Title = "The Gorgias",
                FirstName = "",
                LastName = "",
                Price = 9.99m,
                Name = "Plato",
            });



            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\books.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, p1);
                MessageBox.Show("Created");

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Books> p1 = new List<Books>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Books>));



            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "//books.xml", FileMode.Open, FileAccess.Read))
            {
                p1 = serializer.Deserialize(fs) as List<Books>;

            }
            datagrid1.ItemsSource = p1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var doc = new XmlDocument();
            doc.Load("books.xml");
            XmlNode node = doc.DocumentElement;
            //datagrid1.ItemsSource = node.LocalName;
           // textbox1.Text = node.LocalName;
            MessageBox.Show("reading in process");
            foreach (XmlNode books in node.ChildNodes)
            {
                Console.WriteLine("Found Book:");
                foreach (XmlNode book in books.ChildNodes)
                {
                    textbox1.Text=book.Name  + book.InnerText;
                    
                }


                // Напечатает сначала строку Title-150, затем Title-2150.
                // Эти строки являются слиянием текста двух узлов корневого элемента.
                //    Console.WriteLine(books.InnerText);
                
            }
          
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FileStream stream = new FileStream("books.xml", FileMode.Open);

            XmlTextReader reader = new XmlTextReader(stream);
            while (reader.Read())
            {
               // textbox1.Text = reader.NodeType.ToString();
               // listbox1.ItemsSource = reader.Value;
            }
            listbox1.ItemsSource = reader.Name;
            reader.Close();
        }
    }
}
