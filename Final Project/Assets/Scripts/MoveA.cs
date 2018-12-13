using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveA : MonoBehaviour {

    public GetData getDataScript;
    public GameObject posA;
    //variables for coordinates
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        posA.transform.position = new Vector3(getDataScript.locA_x, getDataScript.locA_y, 0f);
        Debug.Log(getDataScript.locA_x +" " +getDataScript.locA_y);

        randomLatittude();
	}

    void randomLatittude()
    {
        float ranNum= Random.Range( -74.221332f, -73.684744f);
        Debug.Log(ranNum);
    }
}
