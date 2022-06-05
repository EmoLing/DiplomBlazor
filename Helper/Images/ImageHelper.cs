using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;

namespace Helper.Images
{
    public class ImageHelper
    {
        //public static List<byte[]> GetImageFromRequest(IFormFileCollection imagesFromRequest)
        //{
        //    var images = new List<byte[]>();

        //    foreach (var image in imagesFromRequest)
        //    {
        //        var fileInfo = new FileInfo(image.FileName);
        //        using var stream = image.OpenReadStream();

        //        using var ms = ConvertToPng(stream., fileInfo);
        //        images.Add(ms.ToArray());
        //    }

        //    return images;
        //}

        public static List<byte[]> GetImageFromRequest(string path, string userName)
        {
            var images = new List<byte[]>();
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
                return new List<byte[]>();

            var files = dirInfo.GetFiles().Where(fi => fi.Name.Contains(userName));

            foreach (var file in files)
            {
                using var stream = new StreamReader(file.FullName);

                using var ms = ConvertToPng(stream, file);
                images.Add(ms.ToArray());
            }

            return images;
        }

        public static MemoryStream ConvertToPng(StreamReader stream, FileInfo fileInfo)
        {
            var ms = new MemoryStream();
            if (GetTypeImage(fileInfo.Extension) is TypeImage.Png)
            {
                stream.BaseStream.CopyTo(ms);
                return ms;
            }


            var image = Image.Load(stream.BaseStream);
            image.SaveAsPng(ms);

            return ms;
        }

        public static void SaveImage(List<byte[]> images, string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
                dirInfo.Create();

            path += "{0}";
            for (int i = 0; i < images.Count; i++)
            {
                string newPath = String.Format(path, i) + ".png";
                using var ms = new MemoryStream(images[i]);
                using var image = Image.Load(ms);
                image.SaveAsPng(newPath);
            }
        }

        private static TypeImage GetTypeImage(string extension)
            => extension switch
            {
                ".jpeg" => TypeImage.Jpeg,
                ".jpg" => TypeImage.Jpg,
                ".png" => TypeImage.Png,
                _ => TypeImage.Undefined
            };

        private enum TypeImage
        {
            Jpeg,
            Jpg,
            Png,
            Undefined
        }
    }
}
