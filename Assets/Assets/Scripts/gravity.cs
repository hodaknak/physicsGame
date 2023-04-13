using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody rb;

    Collider thisCollider;

    TrailRenderer trailRenderer;

    bool inGravityZone;

    public float mass = 1f;

    const float gravConst = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;

        thisCollider = GetComponent<SphereCollider>();

        inGravityZone = false;

        trailRenderer = GetComponent<TrailRenderer>();

        float scale = 0.00745182f * mass + 0.0745182f;

        transform.localScale = new Vector3(scale, scale, scale);
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
            thisCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;

            GameObject[] bodies = GameObject.FindGameObjectsWithTag("body");

            Vector3 force = new Vector3();

            foreach (GameObject body in bodies)
            {
                if (body != gameObject)
                    force += (body.transform.position - transform.position).normalized * (mass * body.GetComponent<gravity>().mass) / (transform.position - body.transform.position).sqrMagnitude;
            }

            force *= Time.deltaTime * gravConst;

            rb.AddForce(Vector3.ClampMagnitude(force, mass * 50));

            trailRenderer.enabled = true;
        } else
        {
            thisCollider.material.bounceCombine = PhysicMaterialCombine.Average;

            trailRenderer.enabled = false;
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("body"))
        {
            Physics.IgnoreCollision(thisCollider, collision.collider, true);
        }
    }*/

}