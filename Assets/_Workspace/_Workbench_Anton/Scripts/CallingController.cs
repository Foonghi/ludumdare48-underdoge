using System.Collections;
using System.Collections.Generic;
using Nvp.Tools.Events.EventBus;
using UnityEngine;

public class CallingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NvpEventBus.DispatchEvent(GameEvent.DoDamage, 25);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            NvpEventBus.DispatchEvent(GameEvent.DoDamage, 42);
        }
    }
}
