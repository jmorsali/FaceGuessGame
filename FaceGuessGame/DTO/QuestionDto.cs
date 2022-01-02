namespace FaceGuessGame.DTO
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string PictureAddress { get; set; }
        public Answers CorrectAnswer { get; set; }
        public bool AnsweredCorrectly { get; set; }


    }

    public enum Answers
    {
        Japanese = 1,
        Chinese = 2,
        Korean = 3,
        Thai = 4,
    }
    public enum ApiResult
    {
        OK = 0,
        Failed = 1,
        Error=2
    }
}