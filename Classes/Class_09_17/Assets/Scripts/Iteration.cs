using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iteration : MonoBehaviour {

    public GameObject[] gos;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < gos.Length; i++)
        {
            Instantiate(gos[i], new Vector3(i - 5, 0, 0), Quaternion.identity);
            
            
            //for (int j = 0; j < 10; j++) {
            //    Instantiate(go, new Vector3(i - 5,  j - 5, 0), Quaternion.identity);
            //}
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
