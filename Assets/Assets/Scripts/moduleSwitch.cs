using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moduleSwitch : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    public void loadModule()
    {
        SceneManager.LoadScene(sceneName);
    }
}
