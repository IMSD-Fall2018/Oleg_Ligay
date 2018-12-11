using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour {

	public GameObject RainDrop;				// what object to drop
	public float RainDropFrequency = 0.5f;	// how often is the drop period
	public int DropMultiplier = 1;	        // how many drops per drop period
	public float DropRadius = 5f;			// 
	private float LastRainDrop;				// when was the last rain drop

	void Update () {

		// is the current time greater than the last time we dropped rain,
		// plus the rain drop frequency?
		if (Time.time > LastRainDrop + RainDropFrequency) {

			// drop multiplier here allows us to drop multiple rain drops at once
			for (int i = 0; i < DropMultiplier; i++) {
				
				// where to drop it
				Vector3 dropLocation = transform.position + (Random.insideUnitSphere * DropRadius);

				// make a rain drop
				GameObject NewDrop = Instantiate (RainDrop, dropLocation, Quaternion.identity);

				// destroy the rain drop after 1 second
				Destroy (NewDrop, 1f);
			
			}
			// record last time dropped so we can do this all again
			LastRainDrop = Time.time;
		}
	}
}
