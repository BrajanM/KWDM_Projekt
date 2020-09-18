using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageLoader : MonoBehaviour
{

    [SerializeField]
    private static Texture2D[] DICOMs;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ChoseImage()
    {
        Texture2D[] dicoms = new Texture2D[1];
        dicoms = Converter.ConvertToTexture(@"C:\Users\Brajan\Renalize\Assets\Textures\IM2.DCM");
        DICOMs = dicoms;
    }
}
