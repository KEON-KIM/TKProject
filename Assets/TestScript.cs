using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	List<Transform> m_objectList;
	List<GameObject> m_hpBarList;
	bool isBool =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBool)
        {
        	Destroy(gameObject,5);
        }
    }

    public void DestroyedObject()
    {
    	isBool = true;
    }

}
