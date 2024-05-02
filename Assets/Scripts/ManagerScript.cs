using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{

    //updateing the Table of 2 selected point
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private TextMeshProUGUI name_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_hp_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_attack_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_defense_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_Speed_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_attackspeed_p1;
    [SerializeField] private TextMeshProUGUI name_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_hp_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_attack_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_defense_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_Speed_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_attackspeed_p2;
    [SerializeField] PointRenderer plotter;

    public Button p1;
    public Button p2;
    [SerializeField] private Sprite p1_notpressed;
    [SerializeField] private Sprite p1_pressed;
    [SerializeField] private Sprite p2_notpressed;
    [SerializeField] private Sprite p2_pressed;

    private List<Dictionary<string, object>> data;
    private bool pick1 = false;
    private bool pick2 = false;
    [SerializeField] RayCast myray;

    //types related
    public List<string> selectedtypes = new List<string>();

    //mydeck related
    public List<string> names_in_selectedpreset;
    public string selectedpresetname;
    
    void Start()
    {
        data = new List<Dictionary<string, object>>();
        p1.onClick.AddListener(() => HandleButtonClickp1());
        p2.onClick.AddListener(() => HandleButtonClickp2());
        selectedpresetname = null;
    }
    private void Update()
    {
        updatetable();
    }
    // Start is called before the first frame update
    public bool addtoselected(string type)
    {
        if (selectedtypes.Count < 8)
        {
            selectedtypes.Add(type);
            return true;
        }
        else
        {
            Debug.Log("max types = 8");
            return false;
        }
    }
    public void removefromselected(string type)
    {
        selectedtypes.Remove(type);
    }
    public bool selectpreset(string presetname,List<string> namesinpreset)
    {
        if (selectedpresetname==null) 
        {
            names_in_selectedpreset = namesinpreset;
            selectedpresetname = presetname;

            return true;
        }
        else
        {
            return false;
        }
    }
    public void deselectpreset(string presetname)
    {
        if (presetname==selectedpresetname)
        {
            names_in_selectedpreset.Clear();
            selectedpresetname = null;
        }
    }
    void HandleButtonClickp1()
    {
        pick2 = false;
        pick1 = !pick1;
    }
    void HandleButtonClickp2()
    {
        pick1 = false;
        pick2 = !pick2;
    }
    public void updatedata()
    {
        data = plotter.pointList;
    }
    public void updatetable()
    {
        if (data.Count > 0)
        {
            //pick is set when P1 is being change and is false when P2 is being changed
            if (pick1)
            {
                p1.image.sprite = p1_pressed;
                name_p1.text = myray.myhitname;
                foreach (Dictionary<string, object> item in data)
                {
                    if (name_p1.text == item["Name"].ToString())
                    {
                        textMeshPro_hp_p1.text = item["HP"].ToString();
                        textMeshPro_attack_p1.text = item["Attack"].ToString();
                        textMeshPro_defense_p1.text = item["Defense"].ToString();
                        textMeshPro_Speed_p1.text = item["Speed"].ToString();
                        textMeshPro_attackspeed_p1.text = item["Sp. Atk"].ToString();
                    }
                }
            }
            else
            {
                p1.image.sprite = p1_notpressed;
                //p1.image.color = new  Color(255,255,255,50);
            }
            if (pick2)
            {
                p2.image.sprite = p2_pressed;
                //p2.image.color = new Color(0, 255, 0, 100);
                name_p2.text = myray.myhitname;
                foreach (Dictionary<string, object> item in data)
                {
                    if (name_p2.text == item["Name"].ToString())
                    {
                        textMeshPro_hp_p2.text = item["HP"].ToString();
                        textMeshPro_attack_p2.text = item["Attack"].ToString();
                        textMeshPro_defense_p2.text = item["Defense"].ToString();
                        textMeshPro_Speed_p2.text = item["Speed"].ToString();
                        textMeshPro_attackspeed_p2.text = item["Sp. Atk"].ToString();
                    }
                }
            }
            else
            {
                p2.image.sprite = p2_notpressed;
                //p2.image.color = new Color(255, 255, 255, 50);
            }
        }
    }

}
