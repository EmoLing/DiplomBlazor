using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model.Coordinates
{
    public record AdCoordinates
    {
        public Guid Guid { get; init; } 
        public Guid AdGuid { get; init; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public AdCoordinates()
        {
        }

        public AdCoordinates(Guid adGuid)
        {
            AdGuid = adGuid;
            Guid = Guid.NewGuid();
        }

        public static decimal GetDecimalFromString(string @string)
        {
            if (string.IsNullOrWhiteSpace(@string))
                return 0;

            if (decimal.TryParse(@string, out decimal result)
                || decimal.TryParse(@string.Replace(',', '.'), out result)
                || decimal.TryParse(@string.Replace('.', ','), out result))
            {
                return result;
            }


            throw new Exception("Не удалось распарсить строку");
        }
    }
}
