using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class switchHand : MonoBehaviour
{
    public GameObject directHand;
    public GameObject rayHand;
    InputDevice device;

    bool previousTriggerValue;
    bool previousGripValue;

    void Start()
    {
        updateDevices();

        directHand.SetActive(true);
        rayHand.SetActive(false);
    }

    private void Update()
    {
        bool triggerValue;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue)) {

            if (triggerValue && !previousTriggerValue)
            {
                directHand.SetActive(false);
                rayHand.SetActive(true);
            }

            previousTriggerValue = triggerValue;
        }

        bool gripValue;
        if (device.TryGetFeatureValue(CommonUsages.gripButton, out gripValue))
        {

            if (gripValue && !previousGripValue)
            {
                directHand.SetActive(true);
                rayHand.SetActive(false);
            }

            previousGripValue = gripValue;
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
