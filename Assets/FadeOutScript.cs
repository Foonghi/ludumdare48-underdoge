using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Tools.Events.EventBus;

public class FadeOutScript : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(DelayFading());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    

    IEnumerator DelayFading()
    {
        float difference = 0.1f;
        float lastAlpha = 1f;

        yield return new WaitForSeconds(5f);

        while (mySpriteRenderer.color.a > 0)
        {
            yield return new WaitForSeconds(0.1f);
            mySpriteRenderer.color = new Color(1f, 1f, 1f, lastAlpha);
            lastAlpha -= difference;
        }
        NvpEventBus.DispatchEvent(GameEvent.OnLeaveCredits, null);
    }

    
}
