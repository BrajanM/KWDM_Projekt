using UnityEngine;
using System.Collections;

public class ImageChanger : MonoBehaviour
{
    public Material MainImage;
    private int indexes = 30-1;



    public void Update()
    {
        ImageChanged();
    }


    public void OnLeftButton()
    {
        TextureHandler.ActualIndex--; 
        if (TextureHandler.ActualIndex >= 0)
        {
            MainImage.mainTexture = TextureHandler.TexturetoRender(TextureHandler.SerieOf2DImages[TextureHandler.ActualIndex]);
        }
        else
        {
            TextureHandler.ActualIndex++;
        }
        


    }


    public void OnRightButton()
    {

        TextureHandler.ActualIndex++;
        if (TextureHandler.ActualIndex <= indexes)
        {
            MainImage.mainTexture = TextureHandler.TexturetoRender(TextureHandler.SerieOf2DImages[TextureHandler.ActualIndex]);
        }
        else
        {
            TextureHandler.ActualIndex--;
        }

    }

    public void ImageChanged()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                TextureHandler.ActualIndex++;
                if (TextureHandler.ActualIndex <= indexes)
                {
                    MainImage.mainTexture = TextureHandler.TexturetoRender(TextureHandler.SerieOf2DImages[TextureHandler.ActualIndex]);
                }
                else
                {
                    TextureHandler.ActualIndex--;
                }
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                TextureHandler.ActualIndex--;
                if (TextureHandler.ActualIndex >= 0)
                {
                    MainImage.mainTexture = TextureHandler.TexturetoRender(TextureHandler.SerieOf2DImages[TextureHandler.ActualIndex]);
                }
                else
                {
                    TextureHandler.ActualIndex++;
                }
            }
        }

    }
}
