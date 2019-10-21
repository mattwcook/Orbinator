using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad;
    public Material highlightMaterial;
    Material originalMaterial;
    bool mouseOver = false;

    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel(levelToLoad);
            }
        }
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material = highlightMaterial;
        mouseOver = true;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = originalMaterial;
        mouseOver = false;
    }
}
