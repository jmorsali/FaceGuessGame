using System.Collections.Generic;
using FaceGuessGame.DTO;

namespace FaceGuessGame.Contract
{
    public interface IQuestionManger
    {
        QuestionDto GetNextQuestion();
        List<QuestionDto> ResetQuestionManager();
        UserScoreDto SaveUserAnswer(int QuestionId, Answers? UserAnswer);
    }
}