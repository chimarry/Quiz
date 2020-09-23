using System;
using System.Threading.Tasks;
using System.Windows;

namespace AqoonQuiz.UI
{
    /// <summary>
    /// Interaction logic for QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        private QuestionWindow()
        {
            InitializeComponent();
            AddMusic();
        }

        public static async Task<QuestionWindow> CreateQuestionWindow()
        {
            QuestionWindow questionWindow = new QuestionWindow();
            QuestionPage page = await QuestionPage.CreateQuestionPage();
            questionWindow.QuestionFrame.Content = page;
            return questionWindow;
        }

        private void AddMusic()
        {
            MediaTimelineElement.Source = new Uri(@"UI/Music/Theme.mp3", UriKind.Relative);
        }
    }
}
