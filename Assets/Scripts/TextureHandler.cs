using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureHandler : MonoBehaviour
{
    [SerializeField]
    public static Texture2D[] SerieOf2DImages;
    [SerializeField]
    public static RenderTexture[] SerieOfLeftKidney;
    [SerializeField]
    public static RenderTexture[] SerieOfRightKidney;
    [SerializeField]
    public static RenderTexture DdeafaultPlaneTexture;
    [SerializeField]
    public static Texture2D DdeafaultPlaneTexture2D;
    [SerializeField]
    public static Texture2D LeftMask;
    [SerializeField]
    public static Texture2D RightMask;
    public static float Uleft;
    public static float Uright;
    public static int ActualIndex=0;
    public static Texture2D RenderTo2D(RenderTexture rt)
    {
        Texture2D newTexture = new Texture2D(rt.width, rt.height);
        RenderTexture.active = rt;
        newTexture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        newTexture.Apply();
        return newTexture;
    }
    public static RenderTexture TexturetoRender(Texture2D tex)
    {
        RenderTexture render = new RenderTexture(tex.width, tex.height, 1);
        render.enableRandomWrite = true;

        RenderTexture.active = render;

        Graphics.Blit(tex, render);
        return render;
    }

}
