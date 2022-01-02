using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGuessGame.Contract;

namespace FaceGuessGame.DTO
{
    public class QuestionManger : IQuestionManger
    {
        private readonly List<QuestionDto> availableQuestions;
        public QuestionManger()
        {
            availableQuestions = new List<QuestionDto>
            {
                new QuestionDto{ Id=1 , PictureAddress= "/Content/Img/1.png" , CorrectAnswer= Answers.Korean},
                new QuestionDto{ Id=2 , PictureAddress= "/Content/Img/2.png", CorrectAnswer= Answers.Thai},
                new QuestionDto{ Id=3 , PictureAddress= "/Content/Img/3.png", CorrectAnswer= Answers.Chinese},
                new QuestionDto{ Id=4 , PictureAddress= "/Content/Img/4.png", CorrectAnswer= Answers.Korean},
                new QuestionDto{ Id=5 , PictureAddress= "/Content/Img/5.png", CorrectAnswer= Answers.Japanese},
                new QuestionDto{ Id=6 , PictureAddress= "/Content/Img/6.png", CorrectAnswer= Answers.Thai},
                new QuestionDto{ Id=7 , PictureAddress= "/Content/Img/7.png", CorrectAnswer= Answers.Chinese},
                new QuestionDto{ Id=8 , PictureAddress= "/Content/Img/8.png", CorrectAnswer= Answers.Japanese},
                new QuestionDto{ Id=9 , PictureAddress= "/Content/Img/9.png", CorrectAnswer= Answers.Chinese},
                new QuestionDto{ Id=10 , PictureAddress= "/Content/Img/10.png", CorrectAnswer= Answers.Thai},
            };

        }

        public List<int> ResetQuestionManager()
        {
             HttpContext.Current.Session["ViewedPictures"] = new List<int>();
             return (List<int>)HttpContext.Current.Session["ViewedPictures"];
        }

        public QuestionDto GetNextQuestion()
        {
            var showedQuestions = (List<int>)HttpContext.Current.Session["ViewedPictures"];
            if (showedQuestions == null)
                showedQuestions= ResetQuestionManager();

            var pic = availableQuestions.FirstOrDefault(x => showedQuestions!showedQuestions.Contains(x.Id));
            if (pic != null)
                showedQuestions.Add(pic.Id);

            return pic;
        }

        public UserScoreDto SaveUserAnswer(int QuestionId, Answers? UserAnswer)
        {
            var question = availableQuestions.FirstOrDefault(q => q.Id == QuestionId);
            if (question != null)
            {
                if (UserAnswer.HasValue)
                    question.AnsweredCorrectly = (question.CorrectAnswer == UserAnswer);
                else
                    question.AnsweredCorrectly = false;
            }

            var showedQuestions = (List<int>)HttpContext.Current.Session["ViewedPictures"];
            var positiveScore = availableQuestions.Count(q => showedQuestions.Contains(q.Id) && q.AnsweredCorrectly) * 25;
            var negativeScore = availableQuestions.Count(q => showedQuestions.Contains(q.Id) && !q.AnsweredCorrectly) * 5;

            return new UserScoreDto { PositiveScore= positiveScore ,  NegativeScore= negativeScore};
        }
    }
}