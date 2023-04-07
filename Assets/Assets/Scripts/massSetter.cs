using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class massSetter : MonoBehaviour
{
    [SerializeField, Range(-1, 1)]
    int multiplier;

    [SerializeField]
    spawnBody spawnBodyButton;

    [SerializeField]
    TextMeshPro massDisplay;

    public void onClick()
    {
        float newMass = spawnBodyButton.mass + multiplier;

        if (1 <= newMass && newMass <= 20)
        {
            spawnBodyButton.mass = newMass;
            massDisplay.SetText(spawnBodyButton.mass.ToString());
        }
    }
}
