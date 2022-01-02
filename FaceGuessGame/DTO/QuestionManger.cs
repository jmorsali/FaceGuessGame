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

        public List<QuestionDto> ResetQuestionManager()
        {
            HttpContext.Current.Session["AnswerdQuestions"] = new List<QuestionDto>();
            return (List<QuestionDto>)HttpContext.Current.Session["AnswerdQuestions"];
        }

        public QuestionDto GetNextQuestion()
        {
            var answerdQuestions = (List<QuestionDto>)HttpContext.Current.Session["AnswerdQuestions"] ??
                                   ResetQuestionManager();

            var question = availableQuestions.FirstOrDefault(q => !answerdQuestions.Select(x => x.Id).Contains(q.Id));
            if (question != null)
                answerdQuestions.Add(question);
            return question;
        }

        public UserScoreDto SaveUserAnswer(int QuestionId, Answers? UserAnswer)
        {
            var answerdQuestions = (List<QuestionDto>)HttpContext.Current.Session["AnswerdQuestions"] ??
                                                    ResetQuestionManager();

            var question = answerdQuestions.FirstOrDefault(q => q.Id == QuestionId);
            if (question != null)
            {
                if (UserAnswer.HasValue)
                    question.AnsweredCorrectly = (question.CorrectAnswer == UserAnswer);
                else
                    question.AnsweredCorrectly = false;
            }
            
            var positiveScore = answerdQuestions.Count(q => q.AnsweredCorrectly) * 25;
            var negativeScore = answerdQuestions.Count(q => !q.AnsweredCorrectly) * 5;

            return new UserScoreDto { PositiveScore = positiveScore, NegativeScore = negativeScore };
        }
    }
}