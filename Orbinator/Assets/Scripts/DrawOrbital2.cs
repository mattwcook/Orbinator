using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOrbital2 : MonoBehaviour
{   
    public float radius;
    public float inclinationAngle;
    public Material orbitalMaterial;
    public float lineThickness;
    Vector3[] verticeArray;
    GameObject debrisAnchor;
    public int debrisCount = 7200;
    public int debrisScatterRange = 15;
    public System.Random ran = new System.Random();
    float rotationPosition = 0.0f;

    public float[] debrisScale = new float[]{0.001f, 0.01f, 0.1f, 1.0f, 10.0f}; 

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
    

        // scatter debris at random points on the circle
        debrisAnchor = new GameObject();
        for (int j = 0; j < debrisCount; j++){
            // debris position
            Vector3 scatterPointChoice = verticeArray[Random.Range(0,360)];
            Vector3 scatterPoint = new Vector3(scatterPointChoice.x + 1.5f*ran.Next(-debrisScatterRange, debrisScatterRange), scatterPointChoice.y + 1.5f*ran.Next(-debrisScatterRange, debrisScatterRange), scatterPointChoice.z + 1.5f*ran.Next(-debrisScatterRange, debrisScatterRange));
            // Vector3 scatterPoint = scatterPointChoice;
            // create sphere for debris
            GameObject newSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newSphere.transform.position = scatterPoint;
            Vector3 newScale = newSphere.transform.localScale;
            newScale *= debrisScale[ran.Next(0, debrisScale.Length)];
            newScale /= 8;
            newSphere.transform.localScale = newScale;
            // set parent
            newSphere.transform.parent = transform;
        }

    }


    // Update is called once per frame
    void Update()
    {
        rotationPosition += 0.2f *Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0.0f, rotationPosition,0.0f);
    }
}
