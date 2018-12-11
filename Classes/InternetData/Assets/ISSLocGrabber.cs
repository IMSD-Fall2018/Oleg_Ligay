using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISSLocGrabber : MonoBehaviour {

	public string url = "http://api.open-notify.org/iss-now.json";

	public Vector3 issposition;

	public bool gotthedata = false;

	// Use this for initialization
	IEnumerator Start () {
		WWW issrawdata = new WWW(url);
		yield return issrawdata;

		JSONObject issdataoutput = new JSONObject(issrawdata.text);
		Debug.Log(issdataoutput.ToString());

		JSONObject iss_positiondata = issdataoutput["iss_position"];

		string longitude = iss_positiondata["longitude"].str;
		Debug.Log(longitude);
		string latitude = iss_positiondata["latitude"].str;

		issposition = new Vector3(float.Parse(longitude), 0, float.Parse(latitude));
		Debug.Log(issposition);
		gotthedata = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
