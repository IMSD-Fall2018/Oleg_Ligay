using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GetData getDataScript;
    public MoveA moveA_Script;
    

	// Use this for initialization
	void Start () {
        DataOutput();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DataOutput()
    {
        Debug.Log(getDataScript.locA_x);
    }
}
