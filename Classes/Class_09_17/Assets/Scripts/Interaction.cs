using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    private Renderer rend; //<--create a renderer
    public Color col;
    private Color startColor;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
	}

    private void OnMouseEnter()
    {
        rend.material.color = col; //<--apply a red color to a material of rend.
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0)) {
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        } else if (Input.GetMouseButton(1))
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
       
        }
        // left click = 0;
        // right click = 1;
        //middle click = 2;
    }

    

    // Update is called once per frame
    void Update () {
		
	}
}
