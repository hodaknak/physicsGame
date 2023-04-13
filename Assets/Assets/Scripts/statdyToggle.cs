using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class statdyToggle : MonoBehaviour
{
    [SerializeField]
    spawnBody spawnBodyButton;

    [SerializeField]
    TextMeshPro buttonText;

    public bool stationary = false;

    public void onClick()
    {
        stationary = !stationary;
        buttonText.text = stationary ? "stationary" : "dynamic";
        spawnBodyButton.stationary = stationary;
    }
}
