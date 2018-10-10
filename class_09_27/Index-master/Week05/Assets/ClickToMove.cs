using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPosition = Vector3.zero;
        if (Input.GetMouseButtonDown(0)){
            //Debug.Log(Input.mousePosition.x / Screen.width); //<-- helps to debug.
            screenPosition.x = Input.mousePosition.x;
            screenPosition.y = Input.mousePosition.y;
            screenPosition.z = -Camera.main.transform.position.z;
            //Debug.Log(screenPosition);

            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            player.transform.position = Camera.main.ScreenToWorldPoint(screenPosition);
        }

        

    }
}
