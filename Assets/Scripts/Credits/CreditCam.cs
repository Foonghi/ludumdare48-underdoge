using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Tools.Events.EventBus;


public class CreditCam : MonoBehaviour
{
    [SerializeField] bool dogeIsVisible = false;
    bool startScroll = false;
    [SerializeField] GameObject theDoge;

    private void OnEnable()
    {
        NvpEventBus.AddListener(GameEvent.OnLeaveCredits, StartScrolling);
    }

    private void OnDisable()
    {
        NvpEventBus.RemoveListener(GameEvent.OnLeaveCredits, StartScrolling);
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (startScroll && (transform.position.y < 125f))
        {
            transform.Translate(Vector2.up * Time.deltaTime * 3f);
        }
        else
        {
            if(!dogeIsVisible && (transform.position.y >= 125f))
            {
                dogeIsVisible = true;
                StartCoroutine(StartTheDoge());
            }
        }
    }
    
    public void StartScrolling(object Nutzlos)
    {
        StartCoroutine(DelayScrolling());
    }

    IEnumerator DelayScrolling()
    {
        yield return new WaitForSeconds(1f);
        startScroll = true;
    }

    IEnumerator StartTheDoge()
    {
        Debug.Log("Beware of the DOGE!");
        yield return new WaitForSeconds(2f);
        GameObject dogeDoge = Instantiate(theDoge, theDoge.transform.position, theDoge.transform.rotation) as GameObject;
    }

}
