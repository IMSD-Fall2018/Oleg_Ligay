using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GetData datascript;

    IEnumerator Start()
    {

        //string url = "https://maps.googleapis.com/maps/api/directions/json?destination=40.695574,-73.987947&origin=40.820133,-74.221332&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";

        string comURL = "https://maps.googleapis.com/maps/api/directions/json?destination=40.695574,-73.987947&origin=40.820133,-74.221332&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";

        WWW www = new WWW(comURL);
  
        yield return www;

        JSONObject tempData = new JSONObject(www.text);
        Debug.Log(tempData);
        //JSONObject steps = tempData["routes"][0]["legs"][0]["steps"][0]["start_location"];

        //Start Location
        JSONObject start = tempData["routes"][0]["legs"][0]["steps"][0]["start_location"];
        float startLat = start["lat"].n;
        float startLong = start["lng"].n;

        //End location
        JSONObject end = tempData["routes"][0]["legs"][0]["steps"][0]["end_location"];
        float endLat = end["lat"].n;
        float endLong = end["lng"].n;

        

        //Log the results
        Debug.Log(startLat);
        Debug.Log(startLong);
        Debug.Log(endLat);
        Debug.Log(endLong);




    }


}


