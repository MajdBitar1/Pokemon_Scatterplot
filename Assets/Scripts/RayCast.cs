using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class RayCast : MonoBehaviour
{
    //public PointRenderer plotter;
    //private List<Dictionary<string, object>> data;
    private Vector3 centerOfScreen;
    public string myhitname;
    [SerializeField] Material mymat;
    [SerializeField] TextMeshProUGUI pokename;
    private Material savedmat;

    public GameObject pre_selection_object = null;
    // Start is called before the first frame update
    void Start()
    {
        centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //data = plotter.pointList;
        var ray = Camera.main.ScreenPointToRay(centerOfScreen);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            var selection = hit.transform;
            if (pre_selection_object != null && Input.GetMouseButtonDown(0) && selection.gameObject.tag == "selectable")
            {
                pre_selection_object.GetComponent<MeshRenderer>().material = savedmat;
            }
            if (selection.gameObject.tag == "selectable")
            {
                myhitname = selection.name;
                pokename.text = myhitname;
                if (Input.GetMouseButtonDown(0))
                {
                    savedmat = selection.gameObject.GetComponent<MeshRenderer>().material;
                    selection.gameObject.GetComponent<MeshRenderer>().material = mymat;
                    pre_selection_object = selection.gameObject;
                }
            }
            if (selection.gameObject.tag == "axisbutton")
            {
                StartCoroutine(Timer(selection.gameObject));
            }

        }
    }

    private IEnumerator Timer(GameObject selection)
    {
        yield return new WaitForSeconds(2f);
        selection.GetComponent<Changeaxisbutton>().changeonhold();
        // Something that happens after 3 seconds
    }
}
