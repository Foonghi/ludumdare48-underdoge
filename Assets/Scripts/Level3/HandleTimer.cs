using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleTimer : MonoBehaviour
{
    Text myText;
    int timeInSeconds = 59;
    int timeInMinutes = 1;
    bool timeIsUp = false;


    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        ClockStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeIsUp)
        {
            return;
        }
        else
        {
            TimeTextUpdater();
        }

    }

    void TimeTextUpdater()
    {
        if (timeInSeconds < 10)
        {
            myText.text = timeInMinutes.ToString() + ":0" + timeInSeconds.ToString();
        }
        else
        {
            myText.text = timeInMinutes.ToString() + ":" + timeInSeconds.ToString();
        }
    }

    void SecondsUpdater()
    {
        if(timeInMinutes == 0 && timeInSeconds <= 1)
        {
            timeIsUp = true;
        }
        else
        {
            timeInSeconds--;
            if (timeInSeconds < 1)
            {
                timeInSeconds = 59;
                timeInMinutes--;
            }
        }
      

    }

    void ClockStart()
    {
        // todo Stop clock counting when game is over with CANCEL INVOKES
        InvokeRepeating("SecondsUpdater", 1f, 1f);
    }
}
