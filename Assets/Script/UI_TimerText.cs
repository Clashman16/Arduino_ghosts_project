using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TimerText : MonoBehaviour
{
    private UnityEngine.UI.Text timerText;
    public PlayerScore score;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score == null)
        {
            score = FindObjectOfType<PlayerScore>();
            setTimerText(score.score);
        }
        if (isPlaying)
        {
            if (Time.time >= score.score)
            {
                setTimerText(score.score);
                score.score = Mathf.FloorToInt(Time.timeSinceLevelLoad) + 1;              
            }
        }
        else
        {
            score.score = 1;
        }
    }

    void setTimerText(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
