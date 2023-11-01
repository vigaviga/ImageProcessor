using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.Application.Effects
{
    public class Blur : IEffect
    {
        public Blur() { }
        public byte[] ApplyEffect<T>(byte[] image, T parameter)
        {
            //apply effect
            return image;
        }
    }
}
