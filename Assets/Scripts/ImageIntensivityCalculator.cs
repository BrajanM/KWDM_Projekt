using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class ImageIntensivityCalculator
    {
        static float MeanIntensivity(RenderTexture renderTexture)
        {
            Texture2D texture = TextureHandler.RenderTo2D(renderTexture);
            Color[] pixels = texture.GetPixels();
            int blackpixelscount = 0;
            float meanValue = 0;
            for (int i = 0; i < pixels.Length; i++)
            {
                if (pixels[i].grayscale!=0)
                {
                    meanValue += pixels[i].grayscale;
                }
                else
                {
                    blackpixelscount++;
                }
                
            }
            meanValue = meanValue / (pixels.Length-blackpixelscount);
            return meanValue;
        }
        public static float[] MeanKidneyIntensivity(RenderTexture[] renderTextures)
        {
            float[] meanValues = new float[renderTextures.Length];
            for (int i = 0; i <meanValues.Length; i++)
            {
                meanValues[i] = MeanIntensivity(renderTextures[i]);
            }
            return meanValues;
        }


    }
}
