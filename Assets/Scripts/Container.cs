using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public void destroychildren()
    {
        var children = new List<GameObject>();
        foreach (Transform child in gameObject.transform)
        { 
            child.gameObject.SetActive(false);
        }
    }
}
