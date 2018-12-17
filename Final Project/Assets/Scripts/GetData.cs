using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GetData : MonoBehaviour {
   
    //string url = "https://maps.googleapis.com/maps/api/directions/json?destination=40.695574,-73.987947&origin=40.820133,-74.221332&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";
    public float locA_x;
    public float locB_x;
    public GameObject posB;
    public float locA_y;
    public float locB_y;
    public string stepByStep;
    float x, y, xEnd, yEnd;
    public GameObject sprite;
    public GameObject endsprite;
    private LineRenderer lineRenderer;
    float counter;


    void Start() {
        isrunning = true;
        StartCoroutine("StartOld");
        
        
    }


    bool isrunning = false;
    IEnumerator StartOld()
    {
        while (isrunning)
        {
            yield return new WaitForSeconds(3f);
            //string url = "https://maps.googleapis.com/maps/api/directions/json?destination=40.695574,-73.987947&origin=40.820133,-74.221332&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";
            string url = "https://maps.googleapis.com/maps/api/directions/json?destination=40.695574,-73.987947&key=AIzaSyBh4yugP-Ux5iHxw4vfK7X6a2a7L4l4lCk&mode=driving";
            string ranLong = randomLongtitude();
            string ranLat = randomLatittude();
            string origin = "&origin=" + ranLat + "," + ranLong;
            string comURL = url + origin;
          
            // fetch the actual info, like you would from a browser
            WWW www = new WWW(comURL);
            // yield return waits for the download to complete before proceeding
            // but since this is in IEnumerator it wont stall the program outright
            yield return www;

            // use a JSON Object to store the info temporarily
            // this makes it easy to access the data struture
            JSONObject tempData = new JSONObject(www.text);

            // this particular API stores all the data under the header
            // "geocodedWaypoints" so first get in there
            JSONObject geocodedWaypoints = tempData["geocoded_waypoints"];

            //Steps
            JSONObject steps = tempData["routes"][0]["legs"][0]["steps"];
            
            //Location A - origin
            float locA_coordinates_lat = tempData["routes"][0]["legs"][0]["start_location"]["lat"].n;
            float locA_coordinates_long = tempData["routes"][0]["legs"][0]["start_location"]["lng"].n;

            //Location B - destination
            float locB_coordinates_lat = tempData["routes"][0]["legs"][0]["end_location"]["lat"].n;
            float locB_coordinates_long = tempData["routes"][0]["legs"][0]["end_location"]["lng"].n;

            //Start Location
            JSONObject start = tempData["routes"][0]["legs"][0]["steps"][0]["start_location"];
            float startLat = start["lat"].n;
            float startLong = start["lng"].n;

            //End location
            JSONObject end = tempData["routes"][0]["legs"][0]["steps"][0]["end_location"];
            float endLat = end["lat"].n;
            float endLong = end["lng"].n;

            // log it just to see whats up

            //Remapped values latts and logs
            locA_x = Remap(locA_coordinates_long, (float)-74.221332, (float)-73.684744, (float)47, (float)425);
             locB_x = Remap(locB_coordinates_long, (float)-74.221332, (float)-73.684744, (float)47, (float)425);
             locA_y = Remap(locA_coordinates_lat, (float)40.582672, (float)40.820133, (float)22, (float)218);
             locB_y = Remap(locB_coordinates_lat, (float)40.582672, (float)40.820133, (float)22, (float)218);
            //float remapped_locA_longitude = Remap()

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
                
                yield return new WaitForSeconds(.2f);
                endsprite.transform.position = new Vector3(xEnd, yEnd);
                yield return new WaitForSeconds(.2f);
                //draw(sprite, endsprite);

            }


            //yield return new WaitForSeconds(3f);
            //ranLong = randomLongtitude();
            //ranLat = randomLatittude();
            yield return new WaitForSeconds(3f);
        }

        //set position to object position B
        posB.transform.position = new Vector3(locB_x, locB_y, 0f);
        Debug.Log(posB + " --> Position B");
    }

    //Remap Values for 
     float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    string randomLongtitude()
    {
        string ranLat = Random.Range(-74.221332f, -73.684744f).ToString();
        return ranLat;
        //Debug.Log(ranLat + " random latitude");
    }

    string randomLatittude()
    {

        string ranLong = Random.Range(40.582672f, 40.820133f).ToString();
        return ranLong;
      
    }


    void draw(GameObject  origin, GameObject destination)
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.transform.position);
        lineRenderer.startWidth = 2f;
        lineRenderer.endWidth = 2f;

        float dist = Vector3.Distance(origin.transform.position, destination.transform.position);
        //float counter;
        if (counter < dist)
        {
            counter += .1f; //Line Draw Speed
            float x = Mathf.Lerp(0, dist, counter);

            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;

            //Get the unit vector in the desired direction, multuply by the desired length and add the starting point
            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            lineRenderer.SetPosition(1, pointAlongLine);
        }
      
    }
}

/*
    1. How to convert Json object into float.
    2. Can not use traffic information because it does not get covered by $300 credit provided by Google.
    3. Map the values from one to another.
    4. String Concatentaion for URL
*/
