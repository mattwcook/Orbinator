using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSelect : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectMaterial;
    public Transform fuelGauge;
    public GameObject drone;
    Material originalMaterial;
    bool ringTouching = false;
    bool selected = false;
    Vector3 fuelGaugeScale;
    float fuelDecrease1;
    float fuelDecrease2;

    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
        fuelGaugeScale = fuelGauge.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (ringTouching == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Select();
            }
        }
        if (selected == true)
        {
            fuelGauge.localScale -= new Vector3(0.5f, 0.0f, 0.0f) * Time.deltaTime;
            
        }
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material = highlightMaterial;
        ringTouching = true;
        if (gameObject.transform.parent.name == "Lower Inclination" || gameObject.transform.parent.name == "Upper Inclination")
        {
            fuelDecrease1 = 1.0f / 4.0f; 
        }
        else
        {
            fuelDecrease1 = 0;
        }
        if (gameObject.name == "torus_116" || gameObject.name == "torus_144")
        {
            fuelDecrease2 = 1.0f / 8.0f;
        }
        else if (gameObject.name == "torus_123" || gameObject.name == "torus_137")
        {
            fuelDecrease2 = 1.0f / 16.0f;
        }
        else
        {
            fuelDecrease2 = 0;
        }
        fuelGauge.localScale = fuelGaugeScale - new Vector3(fuelGaugeScale.x, 0.0f, 0.0f) * (fuelDecrease1 +fuelDecrease2);
    }
    void OnMouseExit()
    {
        ringTouching = false;
        
        if (selected == false)
        {
            GetComponent<Renderer>().material = originalMaterial;
            fuelGauge.localScale = fuelGaugeScale;
        }
        else
        {
            GetComponent<Renderer>().material = selectMaterial;
            fuelGauge.localScale = fuelGaugeScale - new Vector3(fuelGaugeScale.x, 0.0f, 0.0f) * (fuelDecrease1 + fuelDecrease2);
        }
    }

    void Select()
    {
        selected = true;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Renderer>().material = selectMaterial;
        if (gameObject.transform.parent.name == "Middle Inclination" && gameObject.name == "torus_116")
        {
            drone.SetActive(true);
        }

    }
}
