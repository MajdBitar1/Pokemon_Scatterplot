using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypesDisplay : MonoBehaviour
{
    private bool selected = false;
    public string mytype;
    private ManagerScript ms;
    public Button mybutton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = mybutton.GetComponent<Button>();
        ms = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerScript>();
        btn.onClick.AddListener(Updateselect);
    }
    public void Updateselect()
    {
        if (!selected)
        {
            selected = ms.addtoselected(mytype);
            if (selected) { mybutton.image.color = Color.green; }
        }
        else
        {
            ms.removefromselected(mytype);
            selected = false;
            mybutton.image.color = Color.white;
        }
        
    }

}
