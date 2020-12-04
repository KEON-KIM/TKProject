using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.anyKeyDown){
    		Debug.Log("플레이어가 아무 키를 눌렀습니다.");
    	}   
    	if(Input.GetButton("Horizontal")){//횡이동
    		Debug.Log("횡 이동 중 ...." + Input.GetAxisRaw("Horizontal"));
    		//GetAxis = Axis 변화값 가져오기
    		//GetAxisRaw = -1, 1 
    	}
    	if(Input.GetButton("Vertical")){
    		Debug.Log("종 이동 중 ...." + Input.GetAxisRaw("Vertical"));
    	}
    }
}
