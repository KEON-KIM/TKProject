using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
        	Debug.Log("플레이어가 아무키를 눌렀습니다.");
        }
        if(Input.GetButtonDown("Fire1")){
        	Debug.Log("점프!!");
        }
        if(Input.GetButton("Fire1")){
        	Debug.Log("점프 모으는 중 ...");
        }
        if(Input.GetButtonUp("Fire1")){
        	Debug.Log("슈퍼 점프!!");
        }
        if(Input.GetButtonDown("SuperPower")){
        	Debug.Log("필살기 !!");
        }
    
    }
}
