using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver_UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Text TimeText;
    static int Score;
    static float time;
    // Start is called before the first frame update
    void Start()
    {
        if(Player.time <= 0)
        {
            Player.time = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + Player.Score;
        TimeText.text = "Time:" + Player.time;
    }
}
