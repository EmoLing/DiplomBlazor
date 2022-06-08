using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model.Images
{
    public record Image
    {
        public Guid Guid { get; init; }
        public Guid AdGuid { get; init; }
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
