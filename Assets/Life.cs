using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown){
        	Debug.Log("플레이어가 아무 키를 눌렀습니다.");
        }
       	if (Input.anyKey){
       		Debug.Log("플레이어가 아무 키나 누르고 있습니다.");
       	}
       	if (Input.GetKeyDown(KeyCode.Return)){
       		Debug.Log("아이템을 구입하였습니다.");
       	} // GetKey == GetKeyDown 한번만 같은 경우?
       	if (Input.GetKeyUp(KeyCode.RightArrow)){
       		Debug.Log("오른쪽 이동을 멈추었습니다.");
       	}// 키보드를 손에서 떼어냈을 경우.
       	if (Input.GetKey(KeyCode.LeftArrow)){
       		Debug.Log("왼쪽으로 이동중"); //해당 키를 누르고 있는 경우
       	}
       	if (Input.GetMouseButtonDown(0)){
       		Debug.Log("미사일 발사!");
       	} //1 오른쪽, 0왼쪽
       	if (Input.GetMouseButton(0)){
       		Debug.Log("미사일 에너지 모으기!!");
       	}
       	if (Input.GetMouseButtonUp(0)){
       		Debug.Log("에너지파 !!");
       	}
    }
}
