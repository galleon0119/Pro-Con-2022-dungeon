using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{


	[SerializeField]
	private Text ScoreText;
	[SerializeField]
	private Text TimeText;
	Player Player;
	TimeUI TimeUI;
	
	void Start()
	{

		Player = GameObject.Find("player").GetComponent<Player>();
		TimeUI = GameObject.Find("Time_Text").GetComponent<TimeUI>();
        ScoreText.text = "Score:" + Player.Score;
		TimeText.text  = "Time:" + TimeUI.time;
	}

	void Update()
	{

		ScoreText.text = "Score:" + Player.Score;
		TimeText.text = "Time:" + TimeUI.time;

	}
}
