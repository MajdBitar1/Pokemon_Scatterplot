using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class radarchart : MonoBehaviour 
{
    [SerializeField] private Material radarMaterial_P1;
    [SerializeField] private Material radarMaterial_P2;
    private CanvasRenderer radarMeshCanvasRenderer_p1;
    private CanvasRenderer radarMeshCanvasRenderer_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_hp_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_attack_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_defense_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_Speed_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_attackspeed_p1;
    [SerializeField] private TextMeshProUGUI textMeshPro_hp_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_attack_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_defense_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_Speed_p2;
    [SerializeField] private TextMeshProUGUI textMeshPro_attackspeed_p2;



    //////////////////////////////////////
    int hpVertexIndex = 1;
    int attackVertexIndex = 2;
    int defenceVertexIndex = 3;
    int speedVertexIndex = 4;
    int attspeedVertexIndex = 5;
    float angleIncrement = 360f / 5;
    float radarChartSize = 160f;

    private void Awake()
    {
        radarMeshCanvasRenderer_p1 = transform.Find("radarMesh1").GetComponent<CanvasRenderer>();
        radarMeshCanvasRenderer_p2 = transform.Find("radarMesh2").GetComponent<CanvasRenderer>();
    }

    private void Start()
    {
    }


    void Update()
    {
        Mesh mesh1 = new Mesh();
        Mesh mesh2 = new Mesh();
        Vector3[] vertices_p1 = new Vector3[6];
        Vector2[] uv_p1 = new Vector2[6];
        Vector3[] vertices_p2 = new Vector3[6];
        Vector2[] uv_p2 = new Vector2[6];
        int[] triangles_p1 = new int[3 * 5];
        int[] triangles_p2 = new int[3 * 5];
        vertices_p1[0] = Vector3.zero;
        vertices_p2[0] = Vector3.zero;

        //Create P1 Mesh (Red)
        triangles_p1[0] = 0;
        triangles_p1[1] = hpVertexIndex;
        triangles_p1[2] = attackVertexIndex;
        triangles_p1[3] = 0;
        triangles_p1[4] = attackVertexIndex;
        triangles_p1[5] = defenceVertexIndex;
        triangles_p1[6] = 0;
        triangles_p1[7] = defenceVertexIndex;
        triangles_p1[8] = speedVertexIndex;
        triangles_p1[9] = 0;
        triangles_p1[10] = speedVertexIndex;
        triangles_p1[11] = attspeedVertexIndex;
        triangles_p1[12] = 0;
        triangles_p1[13] = attspeedVertexIndex;
        triangles_p1[14] = hpVertexIndex;
        // Create P2 Mesh (Blue)
        triangles_p2[0] = 0;
        triangles_p2[1] = hpVertexIndex;
        triangles_p2[2] = attackVertexIndex;
        triangles_p2[3] = 0;
        triangles_p2[4] = attackVertexIndex;
        triangles_p2[5] = defenceVertexIndex;
        triangles_p2[6] = 0;
        triangles_p2[7] = defenceVertexIndex;
        triangles_p2[8] = speedVertexIndex;
        triangles_p2[9] = 0;
        triangles_p2[10] = speedVertexIndex;
        triangles_p2[11] = attspeedVertexIndex;
        triangles_p2[12] = 0;
        triangles_p2[13] = attspeedVertexIndex;
        triangles_p2[14] = hpVertexIndex;


        Vector3 hpVertex_p1 = Quaternion.Euler(0, 0, -angleIncrement * 0) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_hp_p1.text) / 255);

        Vector3 attackVertex_p1 = Quaternion.Euler(0, 0, -angleIncrement * 1) * Vector3.up * radarChartSize* (float.Parse(textMeshPro_attack_p1.text)/255);
        Vector3 defenceVertex_p1 = Quaternion.Euler(0, 0, -angleIncrement * 2 ) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_defense_p1.text)/255);
        Vector3 speedVertex_p1 = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_Speed_p1.text) / 255);
        Vector3 attspeedVertex_p1 = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_attackspeed_p1.text) / 255);

        vertices_p1[hpVertexIndex] = hpVertex_p1;
        vertices_p1[attackVertexIndex] = attackVertex_p1;
        vertices_p1[defenceVertexIndex] = defenceVertex_p1;
        vertices_p1[speedVertexIndex] = speedVertex_p1;
        vertices_p1[attspeedVertexIndex] = attspeedVertex_p1;

        mesh1.vertices = vertices_p1;
        mesh1.uv = uv_p1;
        mesh1.triangles = triangles_p1;

        radarMeshCanvasRenderer_p1.SetMesh(mesh1);
        radarMeshCanvasRenderer_p1.SetMaterial(radarMaterial_P1,null);


       
        Vector3 hpVertex_p2 = Quaternion.Euler(0, 0, -angleIncrement * 0) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_hp_p2.text) / 255);
        Vector3 attackVertex_p2 = Quaternion.Euler(0, 0, -angleIncrement * 1) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_attack_p2.text) / 255);
        Vector3 defenceVertex_p2 = Quaternion.Euler(0, 0, -angleIncrement * 2) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_defense_p2.text) / 255);
        Vector3 speedVertex_p2 = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_Speed_p2.text) / 255);
        Vector3 attspeedVertex_p2 = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * radarChartSize * (float.Parse(textMeshPro_attackspeed_p2.text) / 255);

        vertices_p2[hpVertexIndex] = hpVertex_p2;
        vertices_p2[attackVertexIndex] = attackVertex_p2;
        vertices_p2[defenceVertexIndex] = defenceVertex_p2;
        vertices_p2[speedVertexIndex] = speedVertex_p2;
        vertices_p2[attspeedVertexIndex] = attspeedVertex_p2;

        mesh2.vertices = vertices_p2;
        mesh2.uv = uv_p2;
        mesh2.triangles = triangles_p2;

        radarMeshCanvasRenderer_p2.SetMesh(mesh2);
        radarMeshCanvasRenderer_p2.SetMaterial(radarMaterial_P2, null);

    }   
    

}