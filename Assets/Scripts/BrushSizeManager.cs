﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class BrushSizeManager: UnityEngine.MonoBehaviour
    {
        public void BrushSizeValue(float brushValue)
        {
            MaskPainting.BrushSize = brushValue;
        }
    }
}