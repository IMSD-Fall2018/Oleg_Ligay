using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GetData : MonoBehaviour {
   
    string url = "https://maps.googleapis.com/maps/api/directions/json?destination=40.695574,-73.987947&origin=40.820133,-74.221332&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";
    public float locA_x;
    public float locB_x;
    public GameObject posB;
    public float locA_y;
    public float locB_y;

    void Start() {
        isrunning = true;
        StartCoroutine("StartOld");

        
    }


    bool isrunning = false;
    IEnumerator StartOld()
    {
        while (isrunning)
        {
            // fetch the actual info, like you would from a browser
            WWW www = new WWW(url);
            // yield return waits for the download to complete before proceeding
            // but since this is in IEnumerator it wont stall the program outright
            yield return www;

            // use a JSON Object to store the info temporarily
            // this makes it easy to access the data struture
            JSONObject tempData = new JSONObject(www.text);

            // this particular API stores all the data under the header
            // "geocodedWaypoints" so first get in there
            JSONObject geocodedWaypoints = tempData["geocoded_waypoints"];
            //Location A - origin
            float locA_coordinates_lat = tempData["routes"][0]["legs"][0]["start_location"]["lat"].n;
            float locA_coordinates_long = tempData["routes"][0]["legs"][0]["start_location"]["lng"].n;

            //Location B - destination
            float locB_coordinates_lat = tempData["routes"][0]["legs"][0]["end_location"]["lat"].n;
            float locB_coordinates_long = tempData["routes"][0]["legs"][0]["end_location"]["lng"].n;
            JSONObject steps = tempData["routes"][0]["legs"][0]["steps"];

            // log it just to see whats up
            Debug.Log("location A " + locA_coordinates_lat + ", " + locA_coordinates_long);
            Debug.Log("location B " + locB_coordinates_lat + ", " + locB_coordinates_long);
          

            //Debug.Log(steps);
            //Remapped values latts and logs
             locA_x = Remap(locA_coordinates_long, (float)-74.221332, (float)-73.684744, (float)47, (float)425);
             locB_x = Remap(locB_coordinates_long, (float)-74.221332, (float)-73.684744, (float)47, (float)425);
             locA_y = Remap(locA_coordinates_lat, (float)40.582672, (float)40.820133, (float)22, (float)218);
             locB_y = Remap(locA_coordinates_lat, (float)40.582672, (float)40.820133, (float)22, (float)218);
            //float remapped_locA_longitude = Remap()
            Debug.Log(locA_x + " x location A");
            //Debug.Log(locB_x + " x location B");
            //Debug.Log(locA_y + " y location A");
            //Debug.Log(locB_y + " y location B");
            //set position to object position B
            posB.transform.position = new Vector3(locB_x, locB_y, 0);
            yield return new WaitForSeconds(5f);
        }
    }

     float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }


}

/*
    1. How to convert Json object into float.
    2. Can not use traffic information because it does not get covered by $300 credit provided by Google.
    3. Map the values from one to another.
    4. String Concatentaion for URL
*/
