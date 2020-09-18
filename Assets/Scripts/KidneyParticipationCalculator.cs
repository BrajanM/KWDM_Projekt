using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Linq;

public class KidneyParticipationCalculator
{

    public static void CalculateParticipation()
    {
        float[] rightKidney = ImageIntensivityCalculator.MeanKidneyIntensivity(TextureHandler.SerieOfRightKidney);
        float[] leftKidney = ImageIntensivityCalculator.MeanKidneyIntensivity(TextureHandler.SerieOfLeftKidney);
        float PmaxValue = rightKidney.Max();
        float PmaxTime = 0;
        for (int i = 0; i < rightKidney.Length; i++)
        {
            if (rightKidney[i]==PmaxValue)
            {
                PmaxTime = i;
                break;
            }
        }
        float LmaxValue = leftKidney.Max();
        float LmaxTime = 0;
        for (int i = 0; i < leftKidney.Length; i++)
        {
            if (leftKidney[i] == LmaxValue)
            {
                LmaxTime = i;
                break;
            }
        }

        float alphaP = PmaxValue / PmaxTime;
        float alphaL = LmaxValue / LmaxTime;

        float Up= alphaP / (alphaP + alphaL);
        float Ul= alphaL / (alphaP + alphaL);
        TextureHandler.Uleft = Ul;
        TextureHandler.Uright = Up;
    }
    
}
