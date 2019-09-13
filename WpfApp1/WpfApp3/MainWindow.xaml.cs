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
            AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(chk_Checked));
            AddHandler(CheckBox.UncheckedEvent, new RoutedEventHandler(chk_Unchecked));
        }
        private void chk_Checked(object sender, RoutedEventArgs e)
        {
            // Копируем ссылку на используемый CheckBox.
            // OriginalSource - свойство содержащее отправителя события.
            CheckBox chk = e.OriginalSource as CheckBox;

            // При помощи системного класса LogicalTreeHelper и его метода FindLogicalNode(),
            // можно выполнить поиск какого либо элемента в XAML коде элемента переданого в аргументы по имени.            
            DependencyObject dpObj = LogicalTreeHelper.FindLogicalNode(panel, chk.Content.ToString());

            // Показываем элемент который мы получили. (Panel1, Panel2, и т.д.)
            ((FrameworkElement)dpObj).Visibility = Visibility.Visible;
        }

        private void chk_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = e.OriginalSource as CheckBox;
            DependencyObject obj = LogicalTreeHelper.FindLogicalNode(panel, chk.Content.ToString());
            ((FrameworkElement)obj).Visibility = Visibility.Collapsed;
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
            XmlDocument document = new XmlDocument();
            document.Load("books.xml");
            textbox1.Text = document.InnerText+":::::::"+ document.InnerXml;
            


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            

            var req = (HttpWebRequest)WebRequest.Create("https://www.nairi-insurance.am/");
           
            req.Method = "GET";

            try
            {
                var resp = (HttpWebResponse)req.GetResponse();
                textbox1.Clear();
                string headersText = resp.Headers.ToString();
                textbox1.Text += headersText;
            }
            catch (WebException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
