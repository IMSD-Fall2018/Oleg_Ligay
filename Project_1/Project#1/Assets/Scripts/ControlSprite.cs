using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSprite : MonoBehaviour
{

    public Vector3 rotationVector;
    // Use this for initialization}
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationVector * Time.deltaTime);
    }


}