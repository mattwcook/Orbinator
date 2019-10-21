using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisDrift : MonoBehaviour
{
    float driftX;
    float driftY;
    float driftZ;
    
    // Start is called before the first frame update
    void Start()
    {
        driftX = Random.Range(0.0f, 1.0f);
        driftY = Random.Range(0.0f, 1.0f);
        driftZ = Random.Range(0.0f, 1.0f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(driftX, driftY, driftZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
