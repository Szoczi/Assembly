using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace sharprdrand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isEncodedNotDecoded = false;
        bool isIntegerNotBinary = false;
        bool isCppNotAsm = false;
        bool isLeftDivideEnabled = false;
        bool isRightDivideEnabled = false;
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                // Display the generated number in the TextBlock
                
                //textBox1.Text = getnumber().ToString();
                //textBox2.Text = CppFunction(5).ToString();


            }
            catch (Exception ex)
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                MessageBox.Show("Error calling native DLL: " + ex.Message + "\nCurrent Directory: " + currentDirectory);
            }

        }
        private void OnLeftDivideButtonClick(object sender, RoutedEventArgs e)
        {
            if (isLeftDivideEnabled)
            {
                LeftBarButton.Opacity = 0.5;
            }
            else
            {
                LeftBarButton.Opacity = 1;
            }
            isLeftDivideEnabled = !isLeftDivideEnabled;
        }
        private void OnRightDivideButtonClick(object sender, RoutedEventArgs e)
        {
            if (isRightDivideEnabled)
            {
                RightBarButton.Opacity = 0.5;
            }
            else
            {
                RightBarButton.Opacity = 1;
            }
            isRightDivideEnabled = !isRightDivideEnabled;
        }

        private void ToggleButtonOpacity(Button activeButton, Button inactiveButton)
        {
            activeButton.Opacity = 1;
            inactiveButton.Opacity = 0.5;
        }

        private void OnEncodeButtonClick(object sender, RoutedEventArgs e)
        {
            if (isEncodedNotDecoded)
            {
                ToggleButtonOpacity(encodeButton, decodeButton);
            }
            else
            {
                ToggleButtonOpacity(decodeButton, encodeButton);
            }
            isEncodedNotDecoded = !isEncodedNotDecoded;
        }

        private void OnDecodeButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isEncodedNotDecoded)
            {
                ToggleButtonOpacity(encodeButton, decodeButton);
            }
            else
            {
                ToggleButtonOpacity(decodeButton, encodeButton);
            }
            isEncodedNotDecoded = !isEncodedNotDecoded;
        }

        private void OnBinaryOutputButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isIntegerNotBinary)
            {
                ToggleButtonOpacity(Binary_Output, Integer_Output);
            }
            else
            {
                ToggleButtonOpacity(Integer_Output, Binary_Output);
            }
            isIntegerNotBinary = !isIntegerNotBinary;
        }

        private void OnIntegerOutputButtonClick(object sender, RoutedEventArgs e)
        {
            if (isIntegerNotBinary)
            {
                ToggleButtonOpacity(Binary_Output, Integer_Output);
            }
            else
            {
                ToggleButtonOpacity(Integer_Output, Binary_Output);
            }
            isIntegerNotBinary = !isIntegerNotBinary;
        }

        private void OnAsmButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isCppNotAsm)
            {
                ToggleButtonOpacity(asm, cpp);
            }
            else
            {
                ToggleButtonOpacity(cpp, asm);
            }
            isCppNotAsm = !isCppNotAsm;
        }

        private void OnCppButtonClick(object sender, RoutedEventArgs e)
        {
            if (isCppNotAsm)
            {
                ToggleButtonOpacity(asm, cpp);
            }
            else
            {
                ToggleButtonOpacity(cpp, asm);
            }
            isCppNotAsm = !isCppNotAsm;
        }



        private void OnButtonRunClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button 2 clicked!");
            // Add your action here
        }


        [DllImport("rdrand.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int getnumber(); 
        [DllImport("cppdll.dll")]
        private static extern int CppFunction(int v);

        private void OnDivideButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
