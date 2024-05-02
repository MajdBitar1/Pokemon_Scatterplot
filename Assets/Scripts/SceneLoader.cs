using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject typesbutton;
    public GameObject MENUTODISPLAY;
    public GameObject mydeck;
    public PointRenderer plotter;
    [SerializeField] Container PointHolder;
    public void onbuttonclick()
    {
        gameObject.SetActive(false);
        mydeck.SetActive(false);
        MENUTODISPLAY.SetActive(true);
    }

    public void backbuttonclick()
    {
        //PointHolder.destroychildren();
        MENUTODISPLAY.SetActive(false);
        typesbutton.SetActive(true);
        mydeck.SetActive(true);
        PointHolder.destroychildren();
        plotter.UpdateData();
    }

    public void mydeckback()
    {
        MENUTODISPLAY.SetActive(false);
        typesbutton.SetActive(true);
        mydeck.SetActive(true);
        PointHolder.destroychildren();
        plotter.presetupdate();
    }
}