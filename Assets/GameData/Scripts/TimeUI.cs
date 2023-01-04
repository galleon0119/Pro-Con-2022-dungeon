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
		time -= Time.deltaTime;//���t���[���̎��Ԃ����Z.
		int minute = (int)time / 60;//��.time��60�Ŋ������l.
		int second = (int)time % 60;//�b.time��60�Ŋ������]��.
		int msecond = (int)(time * 1000 % 1000);
		string minText, secText, msecText;//���E�b��p��.
		if (minute < 10)
			minText = "0" + minute.ToString();//ToString��int��string�ɕϊ�.
		else
			minText = minute.ToString();
		if (second < 10)
			secText = "0" + second.ToString();//��ɓ�����.
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
