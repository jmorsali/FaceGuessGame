using System.Web.Mvc;
using FaceGuessGame.Contract;

namespace FaceGuessGame.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IPictureManger _pictureManager;
        public HomeController(IPictureManger pictureManager)
        {
            _pictureManager = pictureManager;
        }
        public ActionResult Index()
        {
            _pictureManager.ResetPictureManager();
            return View();
        }

        
        [HttpPost]
        public JsonResult getPicInfo()
        {
            var picture = _pictureManager.GetNextPicture();
            return Json(picture);
        }

      
    }
}