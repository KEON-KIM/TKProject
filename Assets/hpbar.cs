using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpbar : MonoBehaviour
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
            m_objectList.Add(t_objects[i].transform);//특정 태그 객체들을 리스트에 추가
            GameObject t_hpbar = Instantiate(m_goPrefab, t_objects[i].transform.position, Quaternion.identity , transform);
            t_objects[i].GetComponent<EnemyZombie>().SetHpBarClone(t_hpbar);
            m_hpBarList.Add(t_hpbar);

            // Debug.Log("asdf");
        }// instantiate는 게임중에 게임오브젝트의 복제본을 생성하는데 사용되는 중요함수
    }//초기화를 어찌해야할까? 계속 띄워주기만하는데..


    // Update is called once per frame
    void Update()
    {
        m_cam = Camera.main;
        if(m_objectList.Count > 0)
        {
            for(int i = 0; i<m_objectList.Count; i++)
            {
                if (m_hpBarList[i]){
                    m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0,2.0f,0));

                }
            }
        }
    }
    public void ReStart()
    {
        m_objectList.Clear();
        m_hpBarList.Clear();

        m_cam = Camera.main;
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Zombie");//특정 태그의 객체들을 배열에 저장
        for(int i = 0; i<t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);//특정 태그 객체들을 리스트에 추가
            GameObject t_hpbar = Instantiate(m_goPrefab, t_objects[i].transform.position, Quaternion.identity , transform);
            t_objects[i].GetComponent<EnemyZombie>().SetHpBarClone(t_hpbar);
            m_hpBarList.Add(t_hpbar);
        }

    }
}
