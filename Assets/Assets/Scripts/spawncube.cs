using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncube : MonoBehaviour
{
    [SerializeField]
    GameObject cube; 

    public void spawnCube()
    {
        Instantiate(cube, new Vector3(0.806f, 2f, -0.216f), Quaternion.identity);
    }
}
