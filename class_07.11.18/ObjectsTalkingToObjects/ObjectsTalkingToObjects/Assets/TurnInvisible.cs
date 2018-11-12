using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInvisible : MonoBehaviour {
    public int enableRenderer;
    public bool switchRend;
    public Renderer rend;
	// Use this for initialization
	void Start () {
       
        rend = GetComponent<Renderer>();
        rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(enableRenderer == 1)
        {
            switchRend = true;
        }
        else
        {
            switchRend = false;
        }

        rend.enabled = switchRend;
	}
}
