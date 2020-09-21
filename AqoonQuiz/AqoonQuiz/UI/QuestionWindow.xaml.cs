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
        }

        public static async Task<QuestionWindow> CreateQuestionWindow()
        {
            QuestionWindow questionWindow = new QuestionWindow();
            QuestionPage page = await QuestionPage.CreateQuestionPage();
            questionWindow.QuestionFrame.Content = page;
            return questionWindow;
        }
    }
}
