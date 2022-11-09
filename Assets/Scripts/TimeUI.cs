using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeUI : MonoBehaviour
{
	public  float time ;
	Text text;

	void Start()
	{
		time = GameObject.Find("GameManager").GetComponent<GameManager>().initTime;
		text = GetComponent<Text>();

	}

	void Update()
	{
		time -= Time.deltaTime;//毎フレームの時間を加算.
		int minute = (int)time / 60;//分.timeを60で割った値.
		int second = (int)time % 60;//秒.timeを60で割った余り.
		int msecond = (int)(time * 1000 % 1000);
		string minText, secText, msecText;//分・秒を用意.
		if (minute < 10)
			minText = "0" + minute.ToString();//ToStringでint→stringに変換.
		else
			minText = minute.ToString();
		if (second < 10)
			secText = "0" + second.ToString();//上に同じく.
		else
			secText = second.ToString();

		if (msecond < 10)
			msecText = "000" + msecond.ToString();

		else if (msecond < 100)
			msecText = "00" + msecond.ToString();

		else if (msecond < 1000)
			msecText = "0" + msecond.ToString();

		else
			msecText = msecond.ToString();
		if (time <= 0)
        {
			time = 0;
			minText =  "0";
        }


		text.text = "[Time] " + minText + ":" + secText + ":" + msecText;

	}

}
