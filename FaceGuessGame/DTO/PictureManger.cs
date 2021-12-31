using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGuessGame.Contract;

namespace FaceGuessGame.DTO
{
    public class PictureManger : IPictureManger
    {
        private readonly List<PictureDto> availablePictutes;
        public PictureManger()
        {
            availablePictutes = new List<PictureDto>
            {
                new PictureDto{ id=1 , PictureAddress= "/Content/Img/1.png"},
                new PictureDto{ id=2 , PictureAddress= "/Content/Img/2.png"},
                new PictureDto{ id=3 , PictureAddress= "/Content/Img/3.png"},
                new PictureDto{ id=4 , PictureAddress= "/Content/Img/4.png"},
                new PictureDto{ id=5 , PictureAddress= "/Content/Img/5.png"},
                new PictureDto{ id=6 , PictureAddress= "/Content/Img/6.png"},
                new PictureDto{ id=7 , PictureAddress= "/Content/Img/7.png"},
                new PictureDto{ id=8 , PictureAddress= "/Content/Img/8.png"},
                new PictureDto{ id=9 , PictureAddress= "/Content/Img/9.png"},
                new PictureDto{ id=10 , PictureAddress= "/Content/Img/10.png"},
            };
            
        }

        public void ResetPictureManager()
        {
            HttpContext.Current.Session["ViewedPictures"] = new List<int>();
        }

        public PictureDto GetNextPicture()
        {
            var showedPictures = (List<int>)HttpContext.Current.Session["ViewedPictures"];
            var pic = availablePictutes.FirstOrDefault(x => !showedPictures.Contains(x.id));
            if (pic != null)
            {
                showedPictures.Add(pic.id);
                //HttpContext.Current.Session["ViewedPictures"] = showedPictures;
            }

            return pic;
        }
    }
}