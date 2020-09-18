using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ZoomHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject Magnifier;

    [SerializeField]
    public Camera ZoomingCamera;
    [SerializeField]
    public GameObject Text3D;
    [SerializeField]
    public GameObject CrossHair;
    public static float ZoomValue=0.5f;

    private TextMesh text;
    private bool zoomActivated = false;
    private bool crossHairActivated = false;


    // Use this for initialization
    void Start()
    {
        Magnifier.SetActive(false);
        text = Text3D.GetComponent<TextMesh>();
        CrossHair.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (zoomActivated)
        {
            ZoomingCamera.orthographicSize = ZoomValue;
            MagnifierMoover();
            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            crossHairActivated = !crossHairActivated;
        }
        if (crossHairActivated)
        {
            CrossHair.SetActive(true);

        }
        else
        {
            CrossHair.SetActive(false);

        }
    }

    public void OnZoomButtonClick()
    {
        zoomActivated = !zoomActivated;
        if (zoomActivated)
        {
            Magnifier.SetActive(true);
        }
        else
        {
            Magnifier.SetActive(false);
        }
    }

    public void MagnifierMoover()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomByShortCut();
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.x > 1.31 && mousePosition.x < 7.51)
            {
                if (mousePosition.y > -3.12 && mousePosition.y < 3.21)
                {
                    Magnifier.transform.position = new Vector3(mousePosition.x, mousePosition.y, Magnifier.transform.position.z);

                }
            }
        }
    }


    public void SliderZoom(float zoomValue)
    {
        ZoomValue = zoomValue;
    }

    public void ZoomByShortCut()
    {
            if (Input.mouseScrollDelta.y>0)
            {
                if (ZoomValue>0)
                {
                    ZoomValue -= 0.1f;

                text.text = ScaleCalculator.CalculateScale().ToString();
                }             
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                if (ZoomValue<1.3)
                {
                    ZoomValue += 0.1f;
                     text.text = ScaleCalculator.CalculateScale().ToString();
                }    
            }
    }
}
