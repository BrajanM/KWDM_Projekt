using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class DiagramPanelManager : MonoBehaviour
{
    [SerializeField]
    public GameObject DiagramPanel;
    [SerializeField]
    public Text leftKidneyValue;
    [SerializeField]
    public Text rightKidneyValue;
    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField]
    LineRenderer lineRenderer2;


    public static bool DiagramVisible = false;

    private void Start()
    {
        DiagramPanel.SetActive(DiagramVisible);
    }
    private void Update()
    {
        if (DiagramVisible)
        {
            DiagramPanel.SetActive(true);

            float[] rightKidney = ImageIntensivityCalculator.MeanKidneyIntensivity(TextureHandler.SerieOfRightKidney);
            float[] leftKidney = ImageIntensivityCalculator.MeanKidneyIntensivity(TextureHandler.SerieOfLeftKidney);
            DrawLeftDiagram(leftKidney);
            DrawRightDiagram(rightKidney);
            KidneyParticipationCalculator.CalculateParticipation();
            double Ur = Mathf.Round(TextureHandler.Uright* 100)/100;
            double Ul = Mathf.Round(TextureHandler.Uleft*100)/100;
            rightKidneyValue.text = "Right kidney: " +Ur.ToString();
            leftKidneyValue.text = "Left kidney: " + Ul.ToString();
        }
        else
        {
            DiagramPanel.SetActive(false);
           
        }
    }

    public void OnPanelDeactivateClick()
    {
        DiagramVisible = false;
        lineRenderer.SetVertexCount(0);
        lineRenderer2.SetVertexCount(0);
    }
    public void DrawLeftDiagram(float[] values)
    {
        float[] xaxis = new float[2] { -9.28f, -1.53f };
        float[] yaxis = new float[2] { -4.98f, -3.43f };
        float[] arguments = new float[values.Length];

        float distance = (-xaxis[0] + xaxis[1]) / (values.Length - 1);

        Vector3[] points = new Vector3[values.Length];
        float x = xaxis[0];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new Vector3(x, yaxis[0] + values[i], 0);
            x += distance;
        }

        lineRenderer.positionCount = points.Length - 1;
        lineRenderer.SetWidth(0.05f, 0.05f);

        lineRenderer.SetColors(UnityEngine.Color.red, UnityEngine.Color.red);
        lineRenderer.SetPositions(points);

    }

    public void DrawRightDiagram(float[] values)
    {
        float[] xaxis = new float[2] { -9.28f, -1.53f };
        float[] yaxis = new float[2] { -3.67f, -2.67f };
        float[] arguments = new float[values.Length];

        float distance = (-xaxis[0] + xaxis[1]) / (values.Length - 1);

        Vector3[] points = new Vector3[values.Length];
        float x = xaxis[0];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new Vector3(x, yaxis[0] + values[i], 0);
            x += distance;
        }
        lineRenderer2.positionCount = points.Length - 1;
        lineRenderer2.SetWidth(0.05f, 0.05f);

        lineRenderer2.SetColors(UnityEngine.Color.red, UnityEngine.Color.red);
        lineRenderer2.SetPositions(points);


    }
}
