using System.Windows;
using System.IO;
using SerializationLibrary;
using System;

namespace bibl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        class Tekst
        {
            public string Text { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tekst data = new Tekst
            {
                Text = dataTextBox.Text
            };
            string filePath = "C:\\Users\\mrpor\\Desktop\\data.json";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            SerializationHelper.Serialize(data, filePath);
            MessageBox.Show("Данные сериализованы");

            Tekst deserializedData = SerializationHelper.Deserialize<Tekst>(filePath);
            MessageBox.Show("Данные десериализованы: " + deserializedData.Text);
        }


        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var darkThemeResource = new ResourceDictionary();
            darkThemeResource.Source = new Uri("pack://application:,,,/ControlLibrary;component/Themes/Dark.xaml");
            Application.Current.Resources.MergedDictionaries[0] = darkThemeResource;

        }

        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var lightThemeResource = new ResourceDictionary();
            lightThemeResource.Source = new Uri("pack://application:,,,/ControlLibrary;component/Themes/Light.xaml");
            Application.Current.Resources.MergedDictionaries[0] = lightThemeResource;
        }
    }
}
