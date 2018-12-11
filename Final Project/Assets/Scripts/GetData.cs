using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GetData : MonoBehaviour {
   
    string url = "https://maps.googleapis.com/maps/api/directions/json?destination=40.6955,-73.9879&origin=40.7484,-73.9857&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";
    
    IEnumerator Start()
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
        Debug.Log(locA_coordinates_lat);
        Debug.Log(locA_coordinates_long);
        Debug.Log(locB_coordinates_lat);
        Debug.Log(locB_coordinates_long);
        
        Debug.Log(steps);

        float remapped_locA_lattitude = Remap(locA_coordinates_lat, (float)40.535290, 23, (float) 40.863813, 218);
        float remapped_locB_lattitude = Remap(locB_coordinates_lat, (float)40.535290, 23, (float)40.863813, 218);
        //float remapped_locA_longitude = Remap()
        Debug.Log(remapped_locA_lattitude + "location A");
        Debug.Log(remapped_locB_lattitude + "location B");
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
