using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Presetselec : MonoBehaviour
{
    public string inputfile;
    private List<Dictionary<string, object>> preset;
    [SerializeField] bool selected = false;
    private string presetname = "Preset1";
    [SerializeField] ManagerScript ms;
    public Button mybutton;
    public List<string> namesinpreset;

    void Start()
    {
        preset = CSVReader.Read(inputfile);
        presetname = gameObject.name;
        foreach (Dictionary<string, object> item in preset)
        {
            namesinpreset.Add( item["Name"].ToString() );
        }
        Button btn = mybutton.GetComponent<Button>();
        btn.onClick.AddListener(Updateselect);

    }


    public void Updateselect()
    {
        if (!selected)
        {
            selected = ms.selectpreset(presetname,namesinpreset);
            if (selected) { mybutton.image.color = Color.green; }
        }
        else
        {
            ms.deselectpreset(presetname);
            selected = false;
            mybutton.image.color = Color.white;
        }

    }
}
