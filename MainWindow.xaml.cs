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

namespace Notepad
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

        private void closeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        private void save(string filename)
        {
            TextPointer start = contentTextBox.Document.ContentStart;
            TextPointer end = contentTextBox.Document.ContentEnd;
            TextRange content = new TextRange(start, end);
            using (var file = new FileStream(filename, FileMode.Create))
            {
                content.Save(file, DataFormats.Rtf);
            }
        }
        private void saveContent(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Rich text format|*.rtf",
                DefaultExt = "rtf"
            };
            var result = dialog.ShowDialog();
            if (result == true)
            {
                save(dialog.FileName);
            }
        }

    }
}
