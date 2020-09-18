using UnityEngine;
using System.Collections;

public class MaskSaver : MonoBehaviour
{
    [SerializeField]
    public RenderTexture MaskTexture;
    public void OnLeftButtonClick()
    {
      
        TextureHandler.LeftMask = TextureHandler.RenderTo2D(MaskTexture);

        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
    public void OnRightButtonClick()
    {
       
        TextureHandler.RightMask = TextureHandler.RenderTo2D(MaskTexture);

        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }

}
