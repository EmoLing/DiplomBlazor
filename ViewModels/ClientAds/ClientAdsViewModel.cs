using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientAds
{
    public class ClientAdsViewModel : MainAdViewModel
    {
        public Guid Guid { get; set; }
        public ClientAdsViewModel() : base()
        {
        }
    }
}
