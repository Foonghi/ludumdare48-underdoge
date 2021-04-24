using System.Collections;
using System.Collections.Generic;
using Nvp.Tools.Events.EventBus;
using UnityEngine;

public class ExampleController : MonoBehaviour
{
    private void OnEnable()
    {
        NvpEventBus.AddListener(GameEvent.Something, DoFoo);
    }

    private void OnDisable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoFoo(object args)
    {
        int dps = (int) args;
        Debug.Log("Schaden: " + dps);
    }

    void DoFoo()
    {
        Debug.Log("Hallo!");
    }
}
