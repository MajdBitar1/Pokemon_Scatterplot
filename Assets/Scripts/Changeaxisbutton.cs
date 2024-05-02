using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeaxisbutton : MonoBehaviour
{
    [SerializeField] WorkshopRowManager rowManager;

    private void OnMouseUpAsButton()
    {
        rowManager.updatechoice(gameObject);
    }

    public void changeonhold()
    {
        rowManager.updatechoice(gameObject);
    }
}
