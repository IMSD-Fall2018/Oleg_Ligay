using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTest : MonoBehaviour {

    public string message;
    public string[] messages;
    public string firstname = "Oleg";
    public string lastname = "Ligay";
    public string[] names;
	// Use this for initialization
	void Start () {
        for(int i = 0; i < messages.Length; i++)
        {
            Debug.Log(messages[Random.Range(0, messages.Length)]);
       
        }
	}
	
	// Update is called once per frame
	void Update () {
	    /*
         Write a madlip story. 
         */	
   	}
}
