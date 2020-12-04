using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar : MonoBehaviour
{
	[SerializeField] GameObject m_goPrefab = null;

	List<Transform> m_objectList = new List<Transform>();
	List<GameObject> m_hpBarList = new List<GameObject>();

	Camera m_cam = null;

    // Start is called before the first frame update
    void Start()
    {
        m_cam = Camera.main;
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Zombie");//특정 태그의 객체들을 배열에 저장
        for(int i = 0; i<t_objects.Length; i++)
        {
        	m_objectList.Add(t_objects[i].transform);
        	GameObject t_hpbar = Instantiate(m_goPrefab, t_objects[i].transform.position, Quaternion.identity , transform);
            m_hpBarList.Add(t_hpbar);
            
            // Debug.Log("asdf");
        }// instantiate는 게임중에 게임오브젝트의 복제본을 생성하는데 사용되는 중요함수
    }//초기화를 어찌해야할까? 계속 띄워주기만하는데..


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Fuckyou");
    	for(int i = 0; i<m_objectList.Count; i++)
        {
        	m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(14f,0.15f,0));
        }
        
    }
}
