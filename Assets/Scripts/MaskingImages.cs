using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class MaskingImages: MonoBehaviour
    {
        [SerializeField]
        private ComputeShader shader;
        

        public RenderTexture[] AllImagesToRender(Texture2D[] images)
        {
            RenderTexture[] rt = new RenderTexture[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                rt[i] = TextureHandler.TexturetoRender(images[i]);
            }
            return rt;
        }

        public void ApplyMaskOnImages()
        {
            Texture2D maskleft = TextureHandler.LeftMask;
            Texture2D maskright= TextureHandler.RightMask;
            TextureHandler.SerieOfLeftKidney = AllImagesToRender(TextureHandler.SerieOf2DImages);
            TextureHandler.SerieOfRightKidney = AllImagesToRender(TextureHandler.SerieOf2DImages);
            for (int i = 0; i < TextureHandler.SerieOfRightKidney.Length; i++)
            {
                TextureHandler.SerieOfRightKidney[i] = ApplyMaskToImage(TextureHandler.SerieOfRightKidney[i], TextureHandler.SerieOf2DImages[i], maskright);
            }
            for (int i = 0; i < TextureHandler.SerieOfRightKidney.Length; i++)
            {
                TextureHandler.SerieOfRightKidney[i] = ApplyMaskToImage(TextureHandler.SerieOfRightKidney[i], TextureHandler.SerieOf2DImages[i], maskleft);
                
            }
            DiagramPanelManager.DiagramVisible = true;

        }
        public RenderTexture ApplyMaskToImage(RenderTexture render, Texture2D image, Texture2D mask)
        {
            int kernelIndex = shader.FindKernel("CalculateImage");
            shader.SetTexture(kernelIndex, "Image", render);
            shader.SetTexture(kernelIndex, "Image2D", image);

            shader.SetTexture(kernelIndex, "ImageMask", mask);
            shader.Dispatch(kernelIndex, 32, 32, 1);

            return render;
        }



    }
}
