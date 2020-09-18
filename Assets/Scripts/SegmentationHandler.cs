using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SegmentationHandler : MonoBehaviour
{


    [SerializeField]
    private Sprite[] inputSprite;





    void Start()
    {
       

        TextureHandler.SerieOf2DImages = new Texture2D[inputSprite.Length];
        for (int  i = 0;  i <inputSprite.Length;  i++)
        {

            TextureHandler.SerieOf2DImages[i] = inputSprite[i].texture;
        }
        ContrastChangingHandler.ContrastAwake = true;

    }

}
