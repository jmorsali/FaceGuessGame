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
                new PictureDto{ id=1 , PicctureAddress= "/Content/Img/1.png"},
                new PictureDto{ id=2 , PicctureAddress= "/Content/Img/2.png"},
                new PictureDto{ id=3 , PicctureAddress= "/Content/Img/3.png"},
                new PictureDto{ id=4 , PicctureAddress= "/Content/Img/4.png"},
                new PictureDto{ id=5 , PicctureAddress= "/Content/Img/5.png"},
                new PictureDto{ id=6 , PicctureAddress= "/Content/Img/6.png"},
                new PictureDto{ id=7 , PicctureAddress= "/Content/Img/7.png"},
                new PictureDto{ id=8 , PicctureAddress= "/Content/Img/8.png"},
                new PictureDto{ id=9 , PicctureAddress= "/Content/Img/9.png"},
                new PictureDto{ id=10 , PicctureAddress= "/Content/Img/10.png"},
            };
            HttpContext.Current.Session["ViewedPictures"] = new List<int>();
        }


        public PictureDto GetNextPicture()
        {
            var showedPictures = (List<int>)HttpContext.Current.Session["ViewedPictures"];
            var pic = availablePictutes.FirstOrDefault(x => !showedPictures.Contains(x.id));
            if (pic != null)
                showedPictures.Add(pic.id);
            return pic;
        }
    }
}