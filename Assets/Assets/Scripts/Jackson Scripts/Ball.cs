using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float mass = 1;
    public Vector3 velocity = new Vector3(0f, 0f, 0f);
    Vector3 velocityleave;
    Vector3 previous = new Vector3(0f, 0f, 0f);
    Vector3 current = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Global.acceleration = Global.forceMagnitude/Global.mass;
        Global.mass = mass;
        Global.velocity = velocity;
        
        this.GetComponent<Rigidbody>().mass = Global.mass = mass;

        velocity = (current - previous) / Time.deltaTime;

        previous = current;
        current = this.transform.position;
    }


    void OnTriggerLeave(Collider other)
    {
        if (other.gameObject.tag == "ForceField")
        {
            velocityleave = velocity;
        }
    }
}
