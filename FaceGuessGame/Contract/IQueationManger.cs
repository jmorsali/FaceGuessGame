using System.Collections.Generic;
using FaceGuessGame.DTO;

namespace FaceGuessGame.Contract
{
    public interface IQuestionManger
    {
        QuestionDto GetNextQuestion();
        List<int> ResetQuestionManager();
        UserScoreDto SaveUserAnswer(int QuestionId, Answers? UserAnswer);
    }
}