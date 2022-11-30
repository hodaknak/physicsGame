using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    float timer = 0;
    public float forceMagnitude = Global.forceMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Ball"){
            timer = 0;
        }
    }
    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Ball") {
            other.gameObject.GetComponent<Rigidbody>().AddForce(forceMagnitude, 0, 0);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Ball"){
            Global.Time = timer;
        }
    }
}
