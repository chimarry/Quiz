using System.Windows;

namespace AqoonQuiz.UI
{
    /// <summary>
    /// Interaction logic for QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        public QuestionWindow()
        {
            InitializeComponent();
            QuestionFrame.Content = new QuestionPage();
        }
    }
}
