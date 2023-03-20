using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody rb;

    bool inGravityZone;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        inGravityZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1490364f);

        inGravityZone = false;
        rb.useGravity = true;

        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("zone"))
            {
                inGravityZone = true;
                rb.useGravity = false;
            }
        }


    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("zone"))
        {
            inGravityZone = true;
            rb.useGravity = false;
        }
    }*/

}
