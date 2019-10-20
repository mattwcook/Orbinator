using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOrbital : MonoBehaviour
{
    public float radius;
    public float inclinationAngle;
    public Material orbitalMaterial;
    public float lineThickness;
    Vector3[] verticeArray;

    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.Euler(inclinationAngle, 0.0f, 0.0f);
        GetComponent<LineRenderer>().startWidth = lineThickness;
        GetComponent<LineRenderer>().useWorldSpace = false;
        GetComponent<Renderer>().material = orbitalMaterial;

        verticeArray = new Vector3[360 + 1];
        GetComponent<LineRenderer>().positionCount = 360 + 1;

        for (int h = 0; h <= 360; h++)
        {
            verticeArray[h] = new Vector3(Mathf.Cos(h * Mathf.PI / 180.0f), 0.0f, Mathf.Sin(h * Mathf.PI / 180.0f)) * radius;
        }
        GetComponent<LineRenderer>().SetPositions(verticeArray);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
