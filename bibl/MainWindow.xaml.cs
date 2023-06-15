using System;
using System.Collections.Generic;
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
using System.IO;
using System.Windows;
using SerializationLibrary;


namespace bibl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string data = dataTextBox.Text;
            string filePath = "C:\\Users\\mrpor\\Desktop\\data.json";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            SerializationHelper.Serialize(data, filePath);
            MessageBox.Show("Данные сериализованы успешно в формате JSON!");

            string deserializedData = SerializationHelper.Deserialize<string>(filePath);
            MessageBox.Show("Данные десериализованы из формата JSON: " + deserializedData);
        }
    }
}
