using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBckrd : MonoBehaviour {


    public Sprite summer, fall, spring, winter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<SpriteRenderer>().sprite = winter;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<SpriteRenderer>().sprite = summer;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<SpriteRenderer>().sprite = fall;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().sprite = spring;
        }
    }
}
