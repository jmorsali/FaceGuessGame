using FaceGuessGame.DTO;

namespace FaceGuessGame.Contract
{
    public interface IPictureManger
    {
        PictureDto GetNextPicture();
        void ResetPictureManager();
    }
}