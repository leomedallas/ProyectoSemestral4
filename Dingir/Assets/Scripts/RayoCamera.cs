using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoCamera : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    /*void Update()
    {
        //if (Input.GetMouseButtonDowen(0)) // Click 0
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit hit; // donde se guarda

            Ray rayo = cam.ScreenPointToRay(Input.mousePosition); // Generamos rayo

            if (Physics.RayCast(rayo, out hit)) // Disparamos raycast
            {
                hit.collider.GetComponent<MeshRenderer>().material.color = Random.ColorHSV;
            }
        }
    }*/
}
