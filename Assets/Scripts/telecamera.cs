using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telecamera : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 3 || Input.GetButtonUp("Jump"))
        {
            Camera.main.transform.position = new Vector3(-7,1.5f,1);
            Camera.main.transform.rotation = new Quaternion(0,-140,0,0);
        }
    }
}
