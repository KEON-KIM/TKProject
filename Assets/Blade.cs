using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blade : MonoBehaviour
{
	public GameObject knight;
  bool isAttack;

	Animator anim;
	Rigidbody Rigid;

  
	// Start is called before the first frame update
  void Awake(){
  	Rigid = GetComponent<Rigidbody>();
	  anim = GetComponent<Animator>();
  }
  

  // Update is called once per frame
  void Update()
  {
    isAttack = knight.GetComponent<Knight>().isAttack;
    //Debug.Log(GetComponent<Knight>().isAttack);
    
   
      // posit = new Vector3(1,1,1);
      // Debug.Log(posit);
      // Debug.Log(knight.transform.position);
  }
  //private void OnCollisionEnter(Collision collision)
 
  //private void OnTriggerEnter(Collider collision)
  
 	private void OnTriggerEnter(Collider collision)
 	{
    if (collision.transform.tag == "Zombie" && isAttack)
    {
      // try
      // {
       // GameObject.FindWithTag("Zombie").GetComponent<EnemyZombie>().Damaged(knight.transform.position);
      collision.transform.GetComponent<EnemyZombie>().Damaged(knight.transform.position);
      // }
      // catch(NullReferenceException ex)
      // {
      //   Debug.Log("Error NullReferenceException"+ex);
      //   // hitting = false;
      // }
      
    }
 	}
}
