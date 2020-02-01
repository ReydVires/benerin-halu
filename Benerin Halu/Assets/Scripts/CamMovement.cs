using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    float boundaries = 3.2f;

    private bool isFungusShows = false;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (!isFungusShows)
        {
            if (Input.GetMouseButton(1))
            {
                Vector3 direction = startPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 pos = Camera.main.transform.position;
                pos.x += direction.x;

                Camera.main.transform.position = new Vector3(Mathf.Clamp(pos.x, -1.2f, 1.2f), pos.y, pos.z);
                    // Debug.Log("B: " + Camera.main.transform.pos);
            }
        }

        // Vector3 initPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void SetCameraAvailability()
    {
        if (!isFungusShows) isFungusShows = true;
        else isFungusShows = false;
    }

    
}