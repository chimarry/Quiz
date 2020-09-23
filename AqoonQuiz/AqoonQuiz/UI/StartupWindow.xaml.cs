using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AqoonQuiz.UI
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When play button is clicked, delegate the call to the question window,
        /// responsible for initalizing quiz.
        /// </summary>
        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = await QuestionWindow.CreateQuestionWindow();
            this.Close();
            window.Show();
        }
    }
}
