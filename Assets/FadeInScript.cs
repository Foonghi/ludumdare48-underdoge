using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Tools.Events.EventBus;

public class FadeInScript : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayFading()
    {
        float difference = 0.05f;
        float lastAlpha = 0f;

        yield return new WaitForSeconds(3f);

        while (mySpriteRenderer.color.a <= 1)
        {
            yield return new WaitForSeconds(0.1f);
            mySpriteRenderer.color = new Color(1f, 1f, 1f, lastAlpha);
            lastAlpha += difference;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player"))
        {
            return;
        }
        else
        {
            StartCoroutine(DelayFading());
        }
    }

}
