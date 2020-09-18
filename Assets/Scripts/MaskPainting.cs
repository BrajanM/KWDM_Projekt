using UnityEngine;
using System.Collections;

public class MaskPainting : MonoBehaviour
{

    public GameObject Brush;
    public static float BrushSize = 1f;
    public RenderTexture RTexture;
    public Camera RenderCamera;
    private bool PaintingAloved = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (PaintingAloved)
            {
                        var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(Ray, out hit))
                        {
                            if (hit.point.x > 0.0 && hit.point.x < 8.5)
                            {
                                if (hit.point.y > -4 && hit.point.y < 4)
                                {
                                    //instanciate a brush
                                    var go = Instantiate(Brush, new Vector3(hit.point.x, hit.point.y, 8), Quaternion.Euler(90, 0, 180), transform);
                                    go.transform.localScale = Vector3.one * BrushSize;
                                }
                            }
                        }              
            }
        }
    }

    public void OnDrawButtonClick()
    {
        PaintingAloved = !PaintingAloved;
        if (PaintingAloved==false)
        {
             var clones = GameObject.FindGameObjectsWithTag("clone");
             foreach (var clone in clones)
             {
                Destroy(clone);
             }
        }
    }



}
