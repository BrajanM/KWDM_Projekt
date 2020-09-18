using UnityEngine;
using System.Collections;

public class ContrastChanger
{
    private ComputeShader computeContrast;
    private ComputeShader computeContrast2;

    public static Texture2D renalImage;


    public static RenderTexture renalImageRT;

   

    public void Initialize(ComputeShader shader, ComputeShader shader2, Texture2D inputImage)
    {
        renalImage = inputImage;
        computeContrast = shader;
        computeContrast2 = shader2;

        renalImageRT = new RenderTexture(renalImage.width, renalImage.height, 1);
        renalImageRT.enableRandomWrite = true;

        RenderTexture.active = renalImageRT;

        Graphics.Blit(renalImage, renalImageRT);

    }

    public void ApplyContrast()
    {
        int kernelIndex = computeContrast.FindKernel("ComputeContrast");
        computeContrast.SetTexture(kernelIndex, "Image", renalImageRT);
        computeContrast.SetTexture(kernelIndex, "Image2D", renalImage);

        computeContrast.Dispatch(kernelIndex, 32, 32, 1);
    }
    public void ApplyContrast2()
    {
        int kernelIndex = computeContrast2.FindKernel("ComputeContrast");
        computeContrast2.SetTexture(kernelIndex, "Image", renalImageRT);
        computeContrast2.SetTexture(kernelIndex, "Image2D", renalImage);

        computeContrast2.Dispatch(kernelIndex, 32, 32, 1);
    }

}
