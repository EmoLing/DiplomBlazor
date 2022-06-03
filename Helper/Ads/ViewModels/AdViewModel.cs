namespace Helper.Ads.ViewModels
{
    public class AdViewModel : MainAdViewModel
    {
        public string UserName { get; set; }
        public Guid UserGuid { get; set; }
        public IList<byte[]> Photo { get; set; }
    }
}
