using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public float minimumscale = 0.1f;
    public float maxscale = 4.5f;
    float lastTapTime = 0;
    float doubletapthreshold = 0.3f;
    // Update is called once per frame
    void Update()
    {
        doubletap();
        if (Input.GetButtonUp("Jump"))
        { 
            gameObject.transform.Rotate(0,45,0);
        }
        pinchzoom();
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }


    void zoom(float increment)
    {
        Vector3 del = new Vector3(increment, increment, increment);
        if (gameObject.transform.localScale.x < minimumscale) { gameObject.transform.localScale = new Vector3(minimumscale, minimumscale, minimumscale); }
        if (gameObject.transform.localScale.x > maxscale) { gameObject.transform.localScale = new Vector3(maxscale, maxscale, maxscale); }
        else
        {
            gameObject.transform.localScale = gameObject.transform.localScale - del;
        }
    }

    void pinchzoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            Vector2 touch1PrevPosition = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPosition = touch2.position - touch2.deltaPosition;

            float prevmag = (touch1PrevPosition - touch2PrevPosition).magnitude;
            float currentmag = (touch1.position - touch2.position).magnitude;

            float magdiff = currentmag - prevmag;
            zoom(-magdiff * 0.01f);
        }
    }
    void doubletap()
    {
        if(Input.touchCount ==1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime <= doubletapthreshold) 
                {
                    lastTapTime = 0;
                    gameObject.transform.Rotate(0, 45, 0);
                }
                else
                {
                    lastTapTime = Time.time;
                }
            }
        }
    }
}
