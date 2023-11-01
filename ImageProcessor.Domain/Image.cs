namespace ImageProcessor.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid OwnersId { get; set; }
        public byte[] ImageData { get; set; }
    }
}