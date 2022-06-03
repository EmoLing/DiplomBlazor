using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model.Ads
{
    public class Image
    {
        public Guid Guid { get; set; }
        public Guid AdGuid { get; set; }
        public Ad Ad { get; set; }
        public byte[] ImageHash { get; set; }

        public Image()
        {

        }

        public Image(Guid adGuid)
        {
            Guid = Guid.NewGuid();
            AdGuid = adGuid;
        }
    }
}
