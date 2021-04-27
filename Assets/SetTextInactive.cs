using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextInactive : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetTextOff());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetTextOff()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
