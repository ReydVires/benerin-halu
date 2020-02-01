using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;

    private bool isFungusShows = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 initPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (!isFungusShows)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 direction = startPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 pos = Camera.main.transform.position;
                pos.x += direction.x;
                Camera.main.transform.position = pos;
               // Debug.Log("B: " + Camera.main.transform.pos);
            }
        }
    }

    void SetCameraAvailability()
    {
        if (!isFungusShows) isFungusShows = true;
        else isFungusShows = false;
    }
}