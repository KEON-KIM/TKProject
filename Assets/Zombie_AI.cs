using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody Rigid;
    public int nextMove; //행동지표 결정 변수

    void Awake(){
		Rigid = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
     	Rigid.velocity = new Vector3(-1, 0, Rigid.velocity.y);
    }
    void Think()
    {
    	
    }
}

