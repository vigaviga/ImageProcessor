using ImageProcessor.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.InternalAPI.Services
{
    public class ImagesService
    {
        public byte[] ApplyEffect(byte[] image, string effect)
        {
            IEffect instance = CreateInstance(effect);
            instance.ApplyEffect(image, 10);
            return image;   
        }

        static IEffect CreateInstance(string effectName)
        {
            Type type = Type.GetType(effectName);

            if (type != null)
            {
                return Activator.CreateInstance(type) as IEffect;
            }
            else
            {
                Console.WriteLine($"Class {effectName} not found.");
                return null;
            }
        }
    }
}
