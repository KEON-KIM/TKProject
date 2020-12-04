using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int stagePoint;
    public int stageIndex=0;
    public Knight player;
    public hpbar Ene_hpbar;
    public Text UIStagePoints;
    public GameObject UIgameover;
    public GameObject UInextstage;
    public GameObject UIcomplete;
    public GameObject UIPlayerDead;

    public GameObject[] Stages;
    public GameObject[] StageTexts;
    public Image[] Lifes;

    int Life_count;


    void Start()
    {
        Life_count = Lifes.Length;
        Debug.Log(Life_count);
    }

    // Update is called once per frame
    void Update()
    {
        UIStagePoints.text = stagePoint.ToString();
    }
    
    public void OnStage()
    {
    	stagePoint += 100;
    }
    public void StageClear()
    {
    	Time.timeScale = 0;
    	UInextstage.SetActive(true);
    }
	public void NextStage()
	{	
		Time.timeScale = 1;
		UInextstage.SetActive(false);
		if(stageIndex <= Stages.Length-2){
			Stages[stageIndex].SetActive(false);
			StageTexts[stageIndex].SetActive(false);
			stageIndex++; 
			Stages[stageIndex].SetActive(true);
			StageTexts[stageIndex].SetActive(true);
			player.GetEnemyList();
			Ene_hpbar.ReStart();
			PlayerReposition();
		}
		else
		{
			UIcomplete.SetActive(true);
			Time.timeScale = 0;
			Debug.Log("The End!! Save the World!! ");
		}
		
	}
	public void PlayerReposition()
	{
		player.transform.position = player.first_pos;
		player.transform.rotation = Quaternion.AngleAxis(0,player.first_dir);
	}

	
	public void LifeMinus()
	{
		Life_count--;
		Lifes[Life_count].color = new Color(1, 0, 0, 0.4f);
	
	}
	public void PlayerDead()
	{
		if(Life_count > 0){
			UIPlayerDead.SetActive(true);
			player.Time_Controller();
		}
		else 
		{
			UIgameover.SetActive(true);
			Time.timeScale = 0 ;
			Debug.Log("Game Over!!");
		}
		
	}
}
