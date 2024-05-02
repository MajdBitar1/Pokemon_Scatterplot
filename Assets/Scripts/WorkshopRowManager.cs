using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopRowManager : MonoBehaviour
{
    [SerializeField] Image HP;
    [SerializeField] Image Attack;
    [SerializeField] Image Def;
    [SerializeField] Image Speed;
    [SerializeField] Image AttSpeed;

    public string choice = "HP";

    public void updatechoice(GameObject obj)
    {
        resetallcolors();
        obj.GetComponent<Image>().color = Color.green;
        choice = obj.name;
    }

    public void resetallcolors()
    {
        HP.color = Color.white;
        Attack.color = Color.white;
        Def.color = Color.white;
        Speed.color = Color.white;
        AttSpeed.color = Color.white;
    }

}
