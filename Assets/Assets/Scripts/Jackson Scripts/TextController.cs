using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI TextVelocity;
    public TextMeshProUGUI TextTime;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(Global.read){
            TextVelocity.text = "Velocity: " + Global.velocity.x.ToString();
        }
        TextTime.text = "Time: " + Global.Time.ToString();

    }
}
