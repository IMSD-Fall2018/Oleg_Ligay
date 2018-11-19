using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadLibs : MonoBehaviour {
    public string[] greetings;
    public string[] names;
    public string[] places;
    public string[] dates;
    public string[] topics;

    public string[] names1;
    public string[] places1;
    public string[] hobbies1;
    public string[] foods1;

    void Start () {
        string finalStory = "";
        finalStory += greetings[Random.Range(0, greetings.Length)];
        finalStory += ", ";
        finalStory += names[Random.Range(0, names.Length)];
        finalStory += ". We have met at  ";
        finalStory += places[Random.Range(0, places.Length)];
        finalStory += ", in  ";
        finalStory += dates[Random.Range(0, dates.Length)];
        finalStory += ". And we had a nice conversation about ";
        finalStory += topics[Random.Range(0, topics.Length)];
        finalStory += ".";
        Debug.Log(finalStory);

        string storyTime = "";
        storyTime += names1[Random.Range(0, names1.Length)];
        storyTime += ", went to the ";
        storyTime += places1[Random.Range(0, places1.Length)];
        storyTime += ", to ";
        storyTime += hobbies1[Random.Range(0, hobbies1.Length)];

        Debug.Log(storyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
