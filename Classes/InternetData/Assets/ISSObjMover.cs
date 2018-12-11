using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISSObjMover : MonoBehaviour {

	public ISSLocGrabber issloc;
	public GameObject spacestation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spacestation.transform.position = issloc.issposition;
	}
}
