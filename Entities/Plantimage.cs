namespace greenhouse.Entities
{
    public class Plantimage
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        // Add this property to store image data as a byte array
        public byte[]? IMAGE_DATA { get; set; }
    }
}