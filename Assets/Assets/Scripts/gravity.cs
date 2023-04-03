using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody rb;

    Collider thisCollider;

    bool inGravityZone;

    public float mass = 1f;

    const float gravConst = 8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        thisCollider = GetComponent<SphereCollider>();

        inGravityZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.08f);

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

        if (inGravityZone)
        {
            GameObject[] bodies = GameObject.FindGameObjectsWithTag("body");

            Vector3 force = new Vector3();

            foreach (GameObject body in bodies)
            {
                if (body != gameObject)
                    force += (body.transform.position - transform.position).normalized * (mass * body.GetComponent<gravity>().mass) / (transform.position - body.transform.position).sqrMagnitude;
            }

            force *= Time.deltaTime * gravConst;

            rb.AddForce(force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("body"))
        {
            Physics.IgnoreCollision(thisCollider, collision.collider, true);
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
