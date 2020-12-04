using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
	public float offsetX = 0f;
	public float offsetY = 25f;
	public float offsetZ = -35f;
	
	Vector3 cameraPosition;
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public GameObject player;
    void LateUpdata (){
    	cameraPosition.x = player.transform.position.x + offsetX;
    	cameraPosition.y = player.transform.position.y + offsetY;
    	cameraPosition.z = player.transform.position.z + offsetZ;
    	
    	transform.position = cameraPosition;
    }
}	
