namespace ImageProcessor.Application
{
    public interface IEffect
    {
        byte[] ApplyEffect<T>(byte[] image, T parameter);
    }
}