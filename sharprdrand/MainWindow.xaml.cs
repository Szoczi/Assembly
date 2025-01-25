using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace sharprdrand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                // Display the generated number in the TextBlock
                
                textBox1.Text = getnumber().ToString();
                textBox2.Text = CppFunction(5).ToString();
            }
            catch (Exception ex)
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                MessageBox.Show("Error calling native DLL: " + ex.Message + "\nCurrent Directory: " + currentDirectory);
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            MessageBox.Show($"Text 1: {text1}\nText 2: {text2}");
        }
        [DllImport("rdrand.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int getnumber(); 
        [DllImport("cppdll.dll")]
        private static extern int CppFunction(int v);  
    }
}
