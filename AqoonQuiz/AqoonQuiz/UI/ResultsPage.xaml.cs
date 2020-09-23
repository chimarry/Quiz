using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AqoonQuiz.UI
{
    /// <summary>
    /// Interaction logic for ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        private static readonly int badResult = Quiz.TotalNumberOfQuestions / 2;
        private const string badResultImage = @"pack://application:,,,/UI/DesignImages/BrainLost.png";
        private const string goodResultImage = @"pack://application:,,,/UI/DesignImages/PinkyWin.png";

        public ResultsPage(int correctAnswersCount)
        {
            InitializeComponent();
            MainGrid.Background = new ImageBrush(new BitmapImage(new Uri(correctAnswersCount > badResult ? goodResultImage : badResultImage)));
            FinalResultTextBlock.Text = $"{correctAnswersCount} / {Quiz.TotalNumberOfQuestions}";
        }

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            ((QuestionWindow)Window.GetWindow(this)).QuestionFrame
                                                    .Navigate(await QuestionPage.CreateQuestionPage());
        }
    }
}
