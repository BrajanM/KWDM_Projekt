using UnityEngine;
using System.Collections;

public class ContrastChangingHandler : MonoBehaviour
{
    [SerializeField]
    private Sprite inputSprite;
    [SerializeField]
    private ComputeShader computeMask;
    [SerializeField]
    private ComputeShader computeMask2;
    [SerializeField]
    private RenderTexture afterComputing;
    [SerializeField]
    private Material imageMaterial;
    private ContrastChanger Changer;

    private int contrastUp=0;
    private int contrastDown=0;

    public static bool ContrastAwake = false;
    private int lastIndex=0;

    void Awake()
    {
      
        
    }

    void Update()
    {
        if (lastIndex!= TextureHandler.ActualIndex)
        {
            ContrastAwake = true;
        }
        if (ContrastAwake)
        {
            Texture2D inputImage = TextureHandler.SerieOf2DImages[TextureHandler.ActualIndex];
            TextureHandler.DdeafaultPlaneTexture2D = inputImage;

            TextureHandler.DdeafaultPlaneTexture = TexturetoRender(inputImage);
            Changer = new ContrastChanger();
            Changer.Initialize(computeMask, computeMask2, inputImage);
            ContrastAwake = !ContrastAwake;
            lastIndex = TextureHandler.ActualIndex;
        }
        

        ContrastTrigered();


    }


    public Texture2D RenderTo2D(RenderTexture rt)
    {
        Texture2D newTexture = new Texture2D(rt.width,rt.height);
        RenderTexture.active = rt;
        newTexture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        newTexture.Apply();
        return newTexture;
    }
    public RenderTexture TexturetoRender(Texture2D tex)
    {
        RenderTexture render = new RenderTexture(tex.width, tex.height, 1);
        render.enableRandomWrite = true;

        RenderTexture.active = render;

        Graphics.Blit(tex, render);
        return render;
    }

    public void ContrastTrigered()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (Input.mouseScrollDelta.y > 0)
            {

                if (contrastUp <4)
                {
                    Changer.ApplyContrast();
                    afterComputing = ContrastChanger.renalImageRT;

                    imageMaterial.mainTexture = afterComputing;
                    ContrastChanger.renalImage = RenderTo2D(afterComputing);

                    contrastDown--;
                    contrastUp++;
                }

            }
            if (Input.mouseScrollDelta.y < 0)
            {
                if (contrastDown < 4)
                {
                    Changer.ApplyContrast2();
                    afterComputing = ContrastChanger.renalImageRT;

                    imageMaterial.mainTexture = afterComputing;
                    ContrastChanger.renalImage = RenderTo2D(afterComputing);
                    contrastDown++;
                    contrastUp--;
                }
            }
        }
       
    }
}
