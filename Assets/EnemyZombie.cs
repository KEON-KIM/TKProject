using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyZombie : MonoBehaviour
{   
	public GameManager gameManager;
    
	public Knight player;

	Rigidbody rigid;
    Animator anim;
    List<GameObject> item_list = new List<GameObject>();
    
    float DemagePoints = 0.2f;
    float HealthPoints = 1.0f;

    // public GameObject zombiePrefeb;
    NavMeshAgent nav;
    int nextMove_x;
    int nextMove_z;
   
    Image hpbar;
    bool isPlayerDead;
    public GameObject Item_obj;
    public AudioSource audioSource;
    public AudioClip[] effect_sound;

    // public Image hpbar;
    public float runSpeed;
    public enum CurrentState { idle, trace, attack, dead };
    public CurrentState curState = CurrentState.idle;
    public GameObject healthbar;
    public float traceDist = 12.0f;
    public float attackDist = 1.2f;
    public bool hitting = false;

    // public bool hitting;
	private Vector3 knockback;
    private Vector3 destination;
    private bool isDead = false;
    private bool isFind = false;

 //    private Animator _animator;
 //    
 //    
    private Transform eneTransform;
    private Transform playerTransform;
    private GameObject dropItem;
    	
    void Start(){
        
        // GameObject objgold = GameObject.FindWithTag("Silver").GetComponent<GameObject>();
        // foreach(GameObject child in  objList)
        // {
        //     Debug.Log("Child Name : "+child.name);
        // }
        // Debug.Log("What?"+objSize);
    	audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.8f; 
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.priority = 0;

        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        eneTransform = gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        dropItem = GameObject.FindWithTag("Item").GetComponent<Transform>().gameObject;
        // foreach(GameObject child in dropItem)
        // {
            // Debug.Log("Item Name : "+child.transform.name);
            // item_list.Add(Instantiate(child) as GameObject);
        // }
        for(int i = 0; i < dropItem.transform.childCount; i++)
        {
            GameObject test = dropItem.transform.GetChild(i).gameObject as GameObject;
            item_list.Add(test);
        }
        // item_list = ;//특정 태그의 객체들을 배열에 저장
        // Transform[] objList = 
        // int objSize = Item_obj.transform.childCount;
        // GameObject test = dropItem.Find("S_Coins").gameObject;
        
        // item_list.Add(test);

        // Debug.Log("Fuck you : "+playerTransform.transform.name);
        // hpObject = GameObject.FindWithTag("Hp").GetComponent<t_hpbar>();

        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.speed = runSpeed;


        Think(!isDead);

        StartCoroutine(CheckState());
        StartCoroutine(CheckStateForAction());

        
        
        // Invoke("Think",5);

        // Think();
        // Invoke("Think",5); // 딜레이
    }

    void Think(bool isdead)
    {   
        // nextdir = Random.Range(1 , 3); // 1(x), 2(y)
        if(!isDead && !isFind)
        {
            nextMove_x = UnityEngine.Random.Range(-5, 5); // 
            nextMove_z = UnityEngine.Random.Range(-5, 5); 

            destination = new Vector3(eneTransform.position.x + nextMove_x, 0, eneTransform.position.z + nextMove_z);
         
            // if (nextMove_x != 0 && nextMove_z != 0)
            // {
            //     // hitting = false;
            //     anim.SetBool("walking",true);
            // }
            // 딜레이
        }
        
    }
    void Update()
    {   
    	isPlayerDead = GameObject.Find("Knight").GetComponent<Knight>().isDead;

    	if (destination == eneTransform.position)
        {
            Think(!isDead);
        }

    	else if (HealthPoints <= 0 && !isDead){
            State_Check();
        }
        	
    	
        //if (isDead)
        	//GameObject Clone = Instantiate(zombiePrefeb);
        
        // StartCoroutine();
        
        // nav.SetDestination(playerTransform.transform.position);
       
        // nav.SetDestination(destination);
        

    }
    IEnumerator CheckState()
    {
        while(!isDead)
        {  
            // Debug.Log("Why Dont Move?");
            yield return new WaitForSeconds(0.1f);

            float dist = Vector3.Distance(playerTransform.position,eneTransform.position);

            if (dist <= attackDist && !isPlayerDead) // attack
            {
                nav.SetDestination(playerTransform.position);
                curState = CurrentState.attack;
                isFind = true;
            }
            else if(dist <= traceDist && !isPlayerDead) // running
            {
                nav.SetDestination(playerTransform.position);
                curState = CurrentState.trace; 
                isFind = true;
            }
            else // working
            {
                nav.SetDestination(destination);
                curState = CurrentState.idle;
                isFind = false;
            }
        }
    }
    IEnumerator CheckStateForAction()
    {
		   	// Debug.Log(curState);
        while(!isDead)
        {
            switch(curState)
            {
                case CurrentState.idle :
                	hitting = false;
                    anim.SetBool("running",false);
                    anim.SetBool("walking",true);
                    anim.SetBool("attack",false);
                    break;
                case CurrentState.trace : 
                    nav.Resume();
                    hitting = false;
                    anim.SetBool("running",true);
                    anim.SetBool("walking",false);
                    anim.SetBool("attack",false);
                    break;
                case CurrentState.attack :
                    nav.Resume();
                    hitting = true;
                    anim.SetBool("running",false);
                    anim.SetBool("walking",false);
                    anim.SetBool("attack",true);
                    break;
            }
            yield return null;
        }
    }
    public void SetHpBarClone(GameObject hpbars) 
    {
    	healthbar = hpbars;
    	// hpbar = healthbar.transform.FindChild("imgae");
    	hpbar = healthbar.transform.GetChild(0).GetComponent<Image>();

    	// Debug.Log(greenbar.fillAmount);
    }
    // public void destoryed

    public void Damaged(Vector3 pos)
    {
    	audioSource.clip = effect_sound[0];
    	audioSource.Play();
   		// Debug.Log("What Happen?!");
    	hpbar.fillAmount -= DemagePoints;
    	HealthPoints -=DemagePoints;
    	anim.SetBool("Hitting",true);

	    	
    	
        // hitting = true;
    	//gameObject.transform.position
    	//knockback = new Vector3((gameObject.transform.position.x - pos.x)*30f, 0, (gameObject.transform.position.z - pos.z)*30f);
        // knockback = new Vector3((rigid.position.x - pos.x)*20f, 0, (rigid.position.z - pos.z)*20f);
    	rigid.AddForce(transform.forward*-12.3f, ForceMode.Impulse);
        //gameObject.GetComponent<Blade>().hitting = false;
    }
    public void StateExit() // Animation Setting  if Not Active, it will Delete  
    {
        anim.SetBool("Hitting",false);
        // Debug.Log("Hitting is False");
    }
    private void State_Check()
    {
        // nextMove_x = UnityEngine.Random.Range(-5, 5); 
        isDead = true;
        gameManager.OnStage();
        anim.SetBool("Dead", true); 
        audioSource.clip = effect_sound[1];
        audioSource.Play();
        player.object_count++;
        Destroy(healthbar);
        Destroy(gameObject,5);
        // Invoke("gameManager.OnStage",8);

    }
    private void DropTheItem()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Map" || collision.transform.tag == "Zombie")
        {
            Think(isDead);
            
        }
    }
}
