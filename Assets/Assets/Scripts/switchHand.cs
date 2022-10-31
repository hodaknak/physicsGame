using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class switchHand : MonoBehaviour
{
    public GameObject directHand;
    public GameObject rayHand;
    InputDevice device;

    bool directEnabled;

    bool previousTriggerValue;

    void Start()
    {
        updateDevices();

        directEnabled = true;

        directHand.SetActive(true);
        rayHand.SetActive(false);
    }

    private void Update()
    {
        bool triggerValue;
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out triggerValue)) {

            if (triggerValue && !previousTriggerValue)
            {
                if (directEnabled)
                {
                    directHand.SetActive(true);
                    rayHand.SetActive(false);
                } else
                {
                    directHand.SetActive(false);
                    rayHand.SetActive(true);
                }

                directEnabled = !directEnabled;
            }

            previousTriggerValue = triggerValue;
        }
    }

    private void InputTracking_nodeAdded(XRNodeState obj)
    {
        updateDevices();
    }

    void updateDevices()
    {
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count == 1)
        {
            device = rightHandDevices[0];
        }
        else if (rightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }
    }

}
