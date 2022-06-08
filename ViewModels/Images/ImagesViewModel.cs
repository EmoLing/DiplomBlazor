using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Images
{
    public class ImagesViewModel
    {
        public List<byte[]> ImagesHash { get; set; }
        public Guid adGuid { get; set; }
    }
}
