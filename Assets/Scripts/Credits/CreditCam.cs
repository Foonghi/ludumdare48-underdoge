using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCam : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 3f);
    }
}
