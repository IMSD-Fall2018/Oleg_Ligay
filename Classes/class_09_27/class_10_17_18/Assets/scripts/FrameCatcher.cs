using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCatcher : MonoBehaviour {

    public string folderName = "Screenshots";
    public int frameRate = 30;
    private int frameNum = 0;

	// Use this for initialization
	void Start () {
        //1. Access a class "SYSTEM" that accesses root comands on computer.
        //IO -> In/Out sublclass
        System.IO.Directory.CreateDirectory(folderName);

        Time.captureFramerate = frameRate; //<-- telling Unity to change capture Time.
	}
	
	// Update is called once per frame
	void Update () {
        string fileName = string.Format("{0}/frame{1:D04}.png",folderName,frameNum);
        Debug.Log(fileName);
        ScreenCapture.CaptureScreenshot(fileName);
        frameNum++;
	}
}






