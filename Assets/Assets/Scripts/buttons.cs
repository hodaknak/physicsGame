using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class buttons : MonoBehaviour
{
    Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    public void onHoverEnter()
    {
        render.material.EnableKeyword("_EMISSION");
    }

    public void onHoverExit()
    {
        render.material.DisableKeyword("_EMISSION");
    }
}
