using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _07_IncCanves
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
        private void inkCanvas_Gesture(object sender, InkCanvasGestureEventArgs e)
        {
            String gestures = "";

            // Выборка "предпологаемых" гестур.
            foreach (GestureRecognitionResult res in e.GetGestureRecognitionResults())
                gestures += res.ApplicationGesture.ToString() + "; ";

            // Отображаем название гестуры.
            gestureName.Text = gestures;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Выборка всех режимов редактирования InkCanvas.
            foreach (InkCanvasEditingMode mode in Enum.GetValues(typeof(InkCanvasEditingMode)))
                lstEditingMode.Items.Add(mode);

            lstEditingMode.SelectedItem = inkCanvas.EditingMode;
        }
    }
}
