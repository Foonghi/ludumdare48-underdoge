using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    float movementFactor;
    Vector3 startingPos;

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; // grows continually from 0

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;

    }


}
