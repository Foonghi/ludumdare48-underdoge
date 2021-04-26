using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PoliceCarLightController1 : MonoBehaviour
{
    Light2D myLight;

    // animate the game object from -1 to +1 and back
    public float minimum = 0.1f;
    public float maximum = 1.5f;

    // starting value for the Lerp
    static float t = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // blue 0039FF
        // red FF0800
        // animate the position of the game object...
        myLight.intensity = Mathf.Lerp(minimum, maximum, t);
        myLight.color = Color.Lerp(Color.red, Color.blue, t);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.5f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }


        
    }
}
