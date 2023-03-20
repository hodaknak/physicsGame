using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBody : MonoBehaviour
{
    [SerializeField]
    GameObject body;

    [SerializeField]
    Vector3 coord = new Vector3(0.806f, 2f, -0.216f);

    public void spawn()
    {
        Instantiate(body, coord, Quaternion.identity);
    }
}
