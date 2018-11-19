using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array_Test_Script : MonoBehaviour {
    public float testfloat = 2f;
    //public float[] testfloatarray = new float[50];
    public float[] taskArray = new float[40];
    	
	void Start () {
        //goes grom 70 - 120
		//for(int i = 0; i < testfloatarray.Length; i++)
  //      {
  //          testfloatarray[i] = (float)(70 + i);
  //      }

        for(int i = 0; i < 80; i++)
        {
            taskArray[i] = (float)(i*2);
            
        }

        
	}

	
	
	void Update () {
		
	}
}
