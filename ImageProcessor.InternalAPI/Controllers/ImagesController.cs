using ImageProcessor.InternalAPI.RequestModels;
using ImageProcessor.InternalAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.InternalAPI.Controllers
{
    public class ImagesController
    {
        //this should be done with DI
        public ImagesController() 
        {
        }
        public byte[][] ApplyEffect(ModifyImagesRequest modifyImagesRequest)
        {
            var imageService = new ImagesService();
            foreach(var image in modifyImagesRequest.Images)
            {
                foreach(var effect in modifyImagesRequest.Effects)
                {
                    imageService.ApplyEffect(image, effect);
                }
            }
            throw new NotImplementedException();
        }
    }
}
