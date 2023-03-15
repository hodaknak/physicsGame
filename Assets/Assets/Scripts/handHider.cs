using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handHider : MonoBehaviour
{
    [SerializeField]
    GameObject handMesh;

    public void onGrab()
    {
        handMesh.SetActive(false);
    }

    public void onRelease()
    {
        handMesh.SetActive(true);
    }
}
