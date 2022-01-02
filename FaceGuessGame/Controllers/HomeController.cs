using System;
using System.Web.Mvc;
using FaceGuessGame.Contract;
using FaceGuessGame.DTO;

namespace FaceGuessGame.Controllers
{
    public class HomeController : Controller
    {

        private readonly IQuestionManger _questionManager;
        public HomeController(IQuestionManger pictureManager)
        {
            _questionManager = pictureManager;
        }
        public ActionResult Index()
        {
            _questionManager.ResetQuestionManager();
            return View();
        }


        [HttpPost]
        public JsonResult getQuestionInfo()
        {
            try
            {
                var question = _questionManager.GetNextQuestion();
                if (question != null)
                    return Json(new { Status = ApiResult.OK, data = question });

                return Json(new { Status = ApiResult.Failed, FaileCode = 1, message = "No more Question Available" });
            }
            catch (Exception ex)
            {
                return Json(new { Status = ApiResult.Error, message = ex.ToString() });
            }
        }

        [HttpPost]
        public JsonResult SaveQuestionResult(int questionId, Answers? userAnswer)
        {
            try
            {
                var userScore = _questionManager.SaveUserAnswer(questionId, userAnswer);
                return Json(new { Status = ApiResult.OK, data = userScore });
            }
            catch (Exception ex)
            {
                return Json(new { Status = ApiResult.Error, message = ex.ToString() });
            }
        }

    }
}