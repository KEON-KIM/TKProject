using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttack : MonoBehaviour
{
	public GameObject zombie;
  	bool hitting;
	Animator anim;
	Rigidbody Rigid;
  	Vector3 posit;
  
	// Start is called before the first frame update
    void Start(){
    	Rigid = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();


	}

    // Update is called once per frame
    void Update()
    {
    	hitting =  zombie.GetComponent<EnemyZombie>().hitting;
    }

   	private void OnTriggerEnter(Collider collision)
   	{
	    if (collision.transform.tag == "Player" && hitting){
	    	// hitting = true;
	   
		    GameObject.FindWithTag("Player").GetComponent<Knight>().OnDamaged();
		    // hitting = false;
		 
	 	}
   	}
}
