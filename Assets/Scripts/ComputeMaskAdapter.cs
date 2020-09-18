using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeMaskAdapter
{
  
    private ComputeShader computeMask;

    private Texture2D renalImage;
    private Texture2D renalImageMask;

    public static RenderTexture renalImageRT;
    public RenderTexture renalMaskRT;

    public void Initialize(ComputeShader shader,Texture2D inputImage, Texture2D inputMask)
    {
        renalImage = inputImage;
        renalImageMask = inputMask;
        computeMask = shader;
        
        renalImageRT=new RenderTexture(renalImage.width, renalImage.height, 1);
        renalImageRT.enableRandomWrite = true;

        RenderTexture.active = renalImageRT;

        Graphics.Blit(renalImage, renalImageRT);


        renalMaskRT = new RenderTexture(renalImageMask.width, renalImageMask.height, 1);
        renalMaskRT.enableRandomWrite = true;

        RenderTexture.active = renalMaskRT;

        Graphics.Blit(renalImageMask, renalMaskRT);
        
    }

    public void ApplyMaskToImage()
    {
        int kernelIndex = computeMask.FindKernel("CalculateImage");
        computeMask.SetTexture(kernelIndex,"Image", renalImageRT);
        computeMask.SetTexture(kernelIndex, "Image2D", renalImage);

        computeMask.SetTexture(kernelIndex,"ImageMask", renalImageMask);
        computeMask.Dispatch(kernelIndex,32, 32, 1);
    }



}
