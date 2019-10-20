using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalSelection : MonoBehaviour
{
    public Material orbitalMaterial;
    public Transform orbitalParent;
    public GameObject debrisSmall;
    public GameObject debrisMed;
    public GameObject debrisLarge;
    public GameObject Mothership;

    float radiusMiddle = 130.0f;
    float radiusLeft;
    float radiusFarLeft;
    float radiusRight;
    float radiusFarRight;
    float radialSpacing = 7.0f;
    float inclinationSpacing = 6.0f;
    GameObject orbitalRing;
    float lineThickness = .1f;

    // Relative to Mothership
    float maxAngle;
    float minAngle;
    float maxAltitude;
    float minAltitude;
    float maxInclination;
    float minInclination;

    float junkAngle;
    float junkAltitude;
    float junkInclination;

    Vector3[] verticeArray;

    
    // Start is called before the first frame update
    void Start()
    {
        radiusFarLeft = radiusMiddle - 2 * radialSpacing;
        radiusLeft = radiusMiddle - radialSpacing;
        radiusRight = radiusMiddle + radialSpacing;
        radiusFarRight = radiusMiddle + 2 * radialSpacing;

        for (int i = 0; i<=5; i++)
        {
            for (int h = -1 * Mathf.RoundToInt(inclinationSpacing); h <= Mathf.RoundToInt(inclinationSpacing); h += Mathf.RoundToInt(inclinationSpacing))
            {
                DrawCircle((float)i * radialSpacing + radiusFarLeft, (float)h);
            }
        }


    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawCircle(float radius, float inclinationAngle)
    {
        orbitalRing = new GameObject("ring"); 
        orbitalRing.transform.SetParent(orbitalParent);
        orbitalRing.transform.localRotation = Quaternion.Euler(inclinationAngle, 0.0f, 0.0f);
        orbitalRing.AddComponent<LineRenderer>();
        orbitalRing.GetComponent<LineRenderer>().useWorldSpace = false;
        orbitalRing.GetComponent<LineRenderer>().startWidth = lineThickness;
        orbitalRing.GetComponent<Renderer>().material = orbitalMaterial;
        verticeArray = new Vector3[360 + 1];
        orbitalRing.GetComponent<LineRenderer>().positionCount = 360 + 1;
        for (int i = 0; i <= 360; i++)
        {
            verticeArray[i] = new Vector3(Mathf.Cos(i * Mathf.PI / 180.0f), 0.0f, Mathf.Sin(i * Mathf.PI / 180.0f)) * radius;
        }
        orbitalRing.GetComponent<LineRenderer>().SetPositions(verticeArray);
    }
    
}
