using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class changecolumns : MonoBehaviour
{
    [SerializeField] PointRenderer plotter;
    [SerializeField] WorkshopRowManager x;
    [SerializeField] WorkshopRowManager y;
    [SerializeField] WorkshopRowManager z;
    Dictionary<string, int> col_dict =
              new Dictionary<string, int>(){
                                  {"HP", 2},
                                  {"Attack", 3},
                                  {"Defense", 4},
                                  {"Speed", 5},
                                  {"AttSpeed", 6}
                                 };

    private void FixedUpdate()
    {
        updatecolumns();
    }
    public void updatecolumns()
    {
        plotter.column1 = col_dict[x.choice];
        plotter.column2 = col_dict[y.choice];
        plotter.column3 = col_dict[z.choice];
    }
    
}
