namespace ImageProcessor.Application.Effects
{
    public class Brighten : IEffect
    {
        public byte[] ApplyEffect<T>(byte[] image, T parameter)
        {
            //apply effect
            return image;
        }
    }
}
