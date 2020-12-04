using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
	public GameManager gameManager;
	public AudioSource audioSource;
    public AudioClip[] effect_sound;
    // effect sound[0] = hit
    // efferc sound[1] = dead
    // effect sound[2] = walk
 	public Image hpbar;
	public bool isAttack = false;
	public bool isDead = false;
	public Vector3 first_pos;
	public Vector3 first_dir;
	public int object_count;

	float DemagePoints = 0.192f/20;
    float HealthPoints = 0.192f;
	float JumpPower = 240f;
	Dictionary<string, Action> keyDictionary;
	Animator anim;
	
	int hit = 0;
	bool ishitting = false;
	bool isJumping = false;
	// bool isGround;
	Rigidbody Rigid;
	Collider col;

	
	List<GameObject> enemy_list = new List<GameObject>();
	List<GameObject> life_list = new List<GameObject>();

	void Awake(){
		Rigid = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		col = GetComponent<Collider>();
	}


    // Start is called before the first frame update
    void Start()
    {	
    	audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1.2f; 
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.priority = 0;

		first_pos = gameObject.transform.position;
		first_dir = gameObject.transform.rotation.eulerAngles;
		GameObject[] Life_Array = GameObject.FindGameObjectsWithTag("Life");
		for (int i = 0; i<Life_Array.Length; i++)
		{
			life_list.Add(Life_Array[i]);

		}
		GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Zombie");
		for (int i = 0; i<t_objects.Length; i++)
		{
			enemy_list.Add(t_objects[i]);
		}

    	
    	keyDictionary = new Dictionary<string, Action>{
    		{ "Back", KeyDown_Back},
    		{ "Move", KeyDown_Move},
    		{ "Run", KeyDown_Run},
    		{ "Attack", KeyDown_Attack},
    		{ "Jump", KeyDown_Jump}
    		
    	};

    }

    // Update is called once per frame
    void Update()
    {	
    	if(!isDead)
    	{	
    		KeyActionTool();
    	}
    	if(enemy_list.Count == object_count)
    	{
    		Debug.Log(enemy_list.Count);
    		// object_count = 0;
    		// Invoke("gameManager.StageClear",8);
    		gameManager.StageClear();
    	}
    // 	else
    // 	{	
    // 		if (HealthPoints <= 0.0f && isDead)
    // 		{
    // 			Debug.Log("Update Method First");
				// HealthPoints = 0.192f;
    // 			Invoke("PlayerReset",2);    			
    // 		}
    	// }
		
   		
    }
    private void KeyActionTool(){

   		if (Input.GetKey(KeyCode.A)){
			anim.transform.Rotate (0.0f, -90.0f * Time.deltaTime,0.0f);
			}
		if (Input.GetKey(KeyCode.D)){
			anim.transform.Rotate (0.0f, 90.0f * Time.deltaTime,0.0f);
		}
		if(isJumping==true && Input.GetKey(KeyCode.W))
		{
			// Debug.Log(Time.deltaTime);
			Rigid.AddForce(transform.forward * (120.0f+Time.deltaTime), ForceMode.Impulse );
			if(Input.GetKey(KeyCode.LeftShift))
				Rigid.AddForce(transform.forward * (120.0f+Time.deltaTime), ForceMode.Impulse );

		}
		if(isJumping==true && Input.GetKey(KeyCode.S))
		{
			// Debug.Log(Time.deltaTime);
			Rigid.AddForce(transform.forward * -(80.0f+Time.deltaTime), ForceMode.Impulse );
		}

   		// anim.SetBool("Hitting",false);
		if(Input.anyKeyDown && !isDead){
	   		foreach (var dic in keyDictionary){
	   			if(Input.GetButtonDown(dic.Key)){
	   				dic.Value();
	   			}	
	   		}
	   	}
	   	else{
	   		foreach (var dic in keyDictionary){
	   			if(Input.GetButtonUp(dic.Key)){
	   				dic.Value();
	   			}
	   		}
	   	}

    }
    private void KeyDown_Move(){
    	if (Input.GetButtonDown("Move")&& !anim.GetBool("Walking")) {
    		anim.SetBool("Walking",true);
    		audioSource.clip = effect_sound[2];
			audioSource.Play();
			audioSource.loop = true;
    	}
    	else if (Input.GetButtonUp("Move") && anim.GetBool("Walking")){
     		anim.SetBool("Walking",false);
     		audioSource.Stop();
     		audioSource.loop = false;
  		}
   	}
   	private void KeyDown_Run(){
   		if (Input.GetButtonDown("Run")&& !anim.GetBool("Running")) {
    		anim.SetBool("Running",true);
    		audioSource.clip = effect_sound[2];
    		audioSource.pitch = 2;
    		audioSource.Play();
    		audioSource.loop = true;
    	}
    	else if (Input.GetButtonUp("Run") && anim.GetBool("Running")){
     		anim.SetBool("Running",false);
     		audioSource.pitch = 1;
    		audioSource.Stop();
    		audioSource.loop = false;
     		
  		}
   	}
   	private void KeyDown_Attack(){
   		if (Input.GetButtonDown("Attack")&& !anim.GetBool("Attack")) {
    		anim.SetBool("Attack",true);
    	}
     	else if (Input.GetButtonUp("Attack") && anim.GetBool("Attack")){
     		anim.SetBool("Attack",false);
     	}
    }

   	private void KeyDown_Back(){
   		if (Input.GetButtonDown("Back")&& !anim.GetBool("Back")) {
    		anim.SetBool("Back",true);
    		audioSource.clip = effect_sound[2];
    		audioSource.Play();
    		audioSource.loop = true;
    	}
    	else if (Input.GetButtonUp("Back") && anim.GetBool("Back")){
     		anim.SetBool("Back",false);
     		audioSource.Stop();
     		audioSource.loop = false;

  		}
    
   	}
   	private void KeyDown_Jump(){
   		// isGround = Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y+0.1f);

   		if(isJumping== false){
   			// Debug.Log("jumpping");
   			if(Input.GetButtonDown("Jump")){
	   			/*isJumping = true;*/
	   			if(isJumping == false){
	   				anim.SetBool("Jumping",true);
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
   			anim.SetBool("Jumping",false);
   			
   		}
   		// bool isGold = collision.gameObject.name.Contains("Gold");
   	}
   	public void OnDamaged()
   	{
   		hit++;

    	hpbar.fillAmount -= DemagePoints;
    	HealthPoints -=DemagePoints;
   		if (hit %4 == 0  && hit != 0)
   		{
   			audioSource.clip = effect_sound[0];
    		audioSource.Play();
	    	anim.SetBool("Hitting",true);
	    	ishitting = true;
    	}
    	else if (HealthPoints <= 0){
    		anim.SetBool("Dead",true);
    		isDead=true;
			
    		Debug.Log("healthpoint zero");
    		audioSource.clip = effect_sound[1];
			audioSource.Play();
    		
    	}
   	}

   	public void AttackState_In_Exit()  //Animation 종료시 Boil 변수 변환 메소드
    {	
   			
       	if (!isAttack){
       		isAttack = true;
       		audioSource.clip = effect_sound[3];
			audioSource.Play();

       	}
        else if (isAttack) {
       		isAttack = false;
       		audioSource.Stop();
       	}
        // Debug.Log("Hitting is False");
    }
    public void Hit_StateExit()  //Animation 종료시 Boil 변수 변환 메소드
    {	

  		if (ishitting)
  		{
  			anim.SetBool("Hitting",false);
   			ishitting = false;
  		}
        // Debug.Log("Hitting is False");
    }
    public void Dead_StateExit()
    {
    	anim.SetBool("Dead",false);
    	gameManager.PlayerDead();
    }
    public void GetEnemyList()
    {
    	enemy_list.Clear();
    	GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Zombie");
		for (int i = 0; i<t_objects.Length; i++)
		{
			enemy_list.Add(t_objects[i]);
		}

    }

	private Vector3 AngleToDirection(float angle)
	{
	   	Vector3 direction = transform.forward;

	   	var quaternion  =Quaternion.Euler(0,angle,0);
	   	Vector3 newDirection = quaternion * direction;

	   	return newDirection;
	}
	public void PlayerReset()
	{
		gameManager.UIPlayerDead.SetActive(false);
		Time_Controller();
		isAttack = false;
    	isDead = false;
		hpbar.fillAmount = 0.192f;
		HealthPoints = 0.192f;
		gameObject.transform.position = first_pos; // Revival Player!!, Back to the Starting Position
		gameObject.transform.rotation = Quaternion.AngleAxis(0,first_dir);
		anim.SetBool("Dead",false); 
		anim.SetBool("Hitting",false);

		gameManager.LifeMinus();
		
	}
	public void Time_Controller()
	{
		if(Time.timeScale == 1.0)		
			Time.timeScale = 0;
		
		else 	
			Time.timeScale = 1;
	}

	
}

   	