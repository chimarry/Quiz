using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AqoonQuiz.UI
{
    /// <summary>
    /// Interaction logic for QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        public enum QuestionOrder { A, B, C, D }
        public Quiz Quiz { get; set; }

        private QuestionPage()
        {
            InitializeComponent();
        }

        public static async Task<QuestionPage> CreateQuestionPage(Quiz previousQuiz = null)
        {
            QuestionPage questionPage = new QuestionPage()
            {
                Quiz = await Quiz.CreateQuiz(previousQuiz)
            };
            questionPage.QuestionTextBlock.Text = questionPage.Quiz.CurrentQuestion.Content;
            List<Answer> answers = questionPage.Quiz.CurrentQuestion.Answers;
            string GetAnswer(QuestionOrder order) => answers[(int)order].Content;
            questionPage.AnswerA.Content = GetAnswer(QuestionOrder.A);
            questionPage.AnswerB.Content = GetAnswer(QuestionOrder.B);
            questionPage.AnswerC.Content = GetAnswer(QuestionOrder.C);
            questionPage.AnswerD.Content = GetAnswer(QuestionOrder.D);
            return questionPage;
        }

        public void ColorButtons(string choosenAnswer, string correctAnswer)
        {
            List<Button> answerButtons = new List<Button>() { AnswerA, AnswerB, AnswerC, AnswerD };
            answerButtons.ForEach(x =>
            {
                if (x.Content.ToString() == correctAnswer)
                    x.Style = (Style)Application.Current.Resources["CorrectAnswer"];
                else if (choosenAnswer != correctAnswer && x.Content.ToString() == choosenAnswer)
                    x.Style = (Style)Application.Current.Resources["WrongAnswer"];
            });
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            Button clickedAnswerButton = (Button)sender;
            Answer correctAnswer = Quiz.ChooseAnswer(clickedAnswerButton.Content.ToString());
            ColorButtons(clickedAnswerButton.Content.ToString(), correctAnswer.Content);
            NextPageButton.IsEnabled = true;
        }

        private async void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            ((QuestionWindow)Window.GetWindow(this)).QuestionFrame
                                                    .Navigate(await CreateQuestionPage(Quiz));
        }
    }
}
