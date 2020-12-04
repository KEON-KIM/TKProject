using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Zombie : MonoBehaviour
{	
	float JumpPower = 5f;
	Dictionary<string, Action> keyDictionary;
	Animator anim;

	bool isJumping = false;
	// bool isGround;
	Rigidbody Rigid;
	Collider col;

	void Awake(){
		Rigid = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		col = GetComponent<Collider>();
	}
    // Start is called before the first frame update
    void Start()
    {
    	keyDictionary = new Dictionary<string, Action>{
    		{ "Back", KeyDown_Back},
    		{ "Move", KeyDown_Move},
    		{ "Run", KeyDown_Run},
    		{ "Attack", KeyDown_Attack},
    		{ "Jump", KeyDown_Jump}
    		
    		// { "Left", KeyDown_Left},
    		// { "Right", KeyDown_Right}
    	};

    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey(KeyCode.A)){
		anim.transform.Rotate (0.0f, -90.0f * Time.deltaTime,0.0f);
	}
	if (Input.GetKey(KeyCode.D)){
		anim.transform.Rotate (0.0f, 90.0f * Time.deltaTime,0.0f);
	}
	
   	if(Input.anyKeyDown){
   		foreach (var dic in keyDictionary){
   			if(Input.GetButtonDown(dic.Key)){
   				dic.Value();
   			}	
   		}
   	}
   	else {
   		foreach (var dic in keyDictionary){
   			if(Input.GetButtonUp(dic.Key)){
   				dic.Value();
   			}
   		}

   	}
   	
   }
    private void KeyDown_Move(){
    	if (Input.GetButtonDown("Move")&& !anim.GetBool("walking")) {
    		anim.SetBool("walking",true);
    	}
    	else if (Input.GetButtonUp("Move") && anim.GetBool("walking")){
     		anim.SetBool("walking",false);
  		}
   	}
   	private void KeyDown_Run(){
   		if (Input.GetButtonDown("Run")&& !anim.GetBool("running")) {
    		anim.SetBool("running",true);
    	}
    	else if (Input.GetButtonUp("Run") && anim.GetBool("running")){
     		anim.SetBool("running",false);
  		}
   	}
   	private void KeyDown_Attack(){
   		if (Input.GetButtonDown("Attack")&& !anim.GetBool("attack")) {
    		anim.SetBool("attack",true);
    	}
    	else if (Input.GetButtonUp("Attack") && anim.GetBool("attack")){
     		anim.SetBool("attack",false);
  		}
   	}
   	private void KeyDown_Back(){
   		if (Input.GetButtonDown("Back")&& !anim.GetBool("back")) {
    		anim.SetBool("back",true);
    	}
    	else if (Input.GetButtonUp("Back") && anim.GetBool("back")){
     		anim.SetBool("back",false);
  		}
    
   	}
   	private void KeyDown_Jump(){
   		// isGround = Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y+0.1f);

   		if(isJumping== false){
   			// Debug.Log("jumpping");
   			if(Input.GetButtonDown("Jump")){
	   			/*isJumping = true;*/
	   			if(isJumping == false){
	   				Rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
	   				isJumping = true;
   				}

   			}
   		}

   	}

   	private void OnCollisionEnter(Collision collision)
   	{
   		if(collision.transform.tag == "Floor")
   		{
   			isJumping = false;
   		}
   	}
   	public void Jumps()
   	{
   		Rigid.AddForce(Vector3.up*10, ForceMode.Impulse);

   	}

   	/*private void OnCollisionExit(Collision collision)
   	{
   		if(collision.transform.tag == "Floor")
   		{
   			isJumping = true;
   			Debug.Log("날아올라");
   		}
   	}*/
   	// private void KeyDown_Right(){
   	// 	if (Input.GetKey(KeyCode.D)) {
    // 		anim.transform.Rotate (0.0f, 180.0f * Time.deltaTime,0.0f);
    // 	}
    // 	// else if (Input.GetButtonUp("Right")){
    // 	// 	anim.transform.Rotate (0.0f, 0.0f ,0.0f);
    // 	// }
   	// }
}

    // if (Input.GetButtonDown("Move")&& !anim.GetBool("walking")) {
    //  	anim.SetBool("walking",true);
    //  	if (Input.GetButtonDown("Run") && !anim.GetBool("running")){
    //  		anim.SetBool("running",true);
    //  		Debug.Log(anim.GetBool("running"));
    //  	}
    //  	else if(Input.GetButtonUp("Run") && anim.GetBool("running")){
    //  		anim.SetBool("running",false);

    //  	}
     	// else if(Input.GetButtonUp("Move")){
     	// 	anim.SetBool("walking", false);
     	// }
     	
     // } 
    //  else if (Input.GetButtonUp("Move") && anim.GetBool("walking")){
    //  	anim.SetBool("walking",false);
  	 // }
  	 // else if (Input.GetButtonDown("Run") && Input.GetButtonDown("Move") && anim.GetBool("walking")){
  	 // 	anim.SetBool("running",true);
  	 // 	Debug.Log("Sibal");
  	 // }
  	 // else if (Input.GetButtonUp("Run") && anim.GetBool("running")){
  	 // 	anim.SetBool("running",false);
  	 // }
  // 	 else if (Input.GetButtonDown("Run") && ! anim.GetBool("running")){
  // 	 	Debug.Log(anim.GetBool("running"));
  // 	 	anim.SetBool("running",true);
  // 	 }
  // 	 else if(Input.GetButtonUp("Run") && anim.GetBool("running")){
  //    		anim.SetBool("running",false);
	 // }
  //    else if (Input.GetButtonDown("Attack") && !anim.GetBool("attack")){
  //    	anim.SetBool("attack",true);
  //    }
  //    else if (Input.GetButtonUp("Attack") && anim.GetBool("attack")){
  //    	anim.SetBool("attack",false);
  //    }
  //   }
