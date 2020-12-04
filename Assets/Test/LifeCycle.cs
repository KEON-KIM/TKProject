using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    void Awake(){
        Debug.Log("Start");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Why don't anything?!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ING~!");
    }
}
