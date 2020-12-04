using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	Vector3 vec = new Vector3(0, 0, 0);
        transform.Translate(vec);  //초기화 할 필요가 없다? 이미 초기화 되어 있다.
        //3차원 == Vector3, 2차원 == Vector2

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
