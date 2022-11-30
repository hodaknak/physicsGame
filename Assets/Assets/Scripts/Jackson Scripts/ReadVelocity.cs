using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadVelocity : MonoBehaviour
{
    public Vector3 ballvelocity;
    Ball ballScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Ball") {
            ballScript = other.gameObject.GetComponent<Ball>();
            Global.read = true;
            //Global.velocity = ballScript.velocity;
            ballvelocity = ballScript.velocity;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Ball"){
            Global.read = false;
        }
    }
}
