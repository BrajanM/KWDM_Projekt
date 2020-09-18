using gdcm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class ScaleCalculator
    {
        public static float CalculateScale() 
        {
            float width = TextureHandler.DdeafaultPlaneTexture2D.width;
            float widthInMetric = width / 1;
            float planeWidth = widthInMetric / 3.3f;
            float zoomValue = ZoomHandler.ZoomValue;
            float planeScaledWidth = planeWidth- ((12-(zoomValue/0.1f))*planeWidth*0.0714f);
            
            float oneCrosValue = planeScaledWidth / 18f;
            return oneCrosValue;

        }
       

    }
}
