using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    GetData datascript;
    GetData DrawLine;
    public GameObject sprite;
    public GameObject endsprite;
    float x, y, xEnd, yEnd;


    IEnumerator Start()
    {

        //string url = "https://maps.googleapis.com/maps/api/directions/json?destination=40.695574,-73.987947&origin=40.820133,-74.221332&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";

        string comURL = "https://maps.googleapis.com/maps/api/directions/json?destination=40.695574,-73.987947&origin=40.820133,-74.221332&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";

        WWW www = new WWW(comURL);

        yield return www;

        JSONObject tempData = new JSONObject(www.text);
        Debug.Log(tempData);
        JSONObject steps = tempData["routes"][0]["legs"][0]["steps"];


        //Start Location
        JSONObject start = tempData["routes"][0]["legs"][0]["steps"][0]["start_location"];
        float startLat = start["lat"].n;
        float startLong = start["lng"].n;

        //End location
        JSONObject end = tempData["routes"][0]["legs"][0]["steps"][0]["end_location"];
        float endLat = end["lat"].n;
        float endLong = end["lng"].n;

        for (int i = 0; i < steps.Count; i++)
        {
            start = steps[i]["start_location"];
            end = steps[i]["end_location"];

            startLat = start["lat"].n;
            x = Remap(startLong, (float)-74.221332, (float)-73.684744, (float)47, (float)425);
            startLong = start["lng"].n;
            y = Remap(startLat, (float)40.582672, (float)40.820133, (float)22, (float)218);
            
            //locA_x = Remap(locA_coordinates_long, (float)-74.221332, (float)-73.684744, (float)47, (float)425);
            //locB_x = Remap(locB_coordinates_long, (float)-74.221332, (float)-73.684744, (float)47, (float)425);
            //locA_y = Remap(locA_coordinates_lat, (float)40.582672, (float)40.820133, (float)22, (float)218);
            //locB_y = Remap(locB_coordinates_lat, (float)40.582672, (float)40.820133, (float)22, (float)218);
            Debug.Log(x + ", " + y);


            endLat = end["lat"].n;
            yEnd = Remap(endLat, (float)40.582672, (float)40.820133, (float)22, (float)218);
            endLong = end["lng"].n;
            xEnd = Remap(endLong, (float)-74.221332, (float)-73.684744, (float)47, (float)425);

            sprite.transform.position = new Vector3(x, y);
            yield return new WaitForSeconds(1f);
            endsprite.transform.position = new Vector3(xEnd, yEnd);
            yield return new WaitForSeconds(1f);

        }


    }


    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }


}


