using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.InternalAPI.RequestModels
{
    public class ModifyImagesRequest
    {
        public byte[][] Images { get; set; }
        public string[] Effects { get; set; }
    }
}
