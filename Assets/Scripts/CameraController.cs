using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 doorPosition;
    private float distance;
    private float startDistance;
    private float threshold;
    private AudioSource cameraAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        cameraAudioSource = gameObject.GetComponent<AudioSource>();
        //only need this once, since the door doesn't move
        doorPosition = GameObject.Find("Tür").transform.position;
        startDistance = Vector2.Distance(player.transform.position, doorPosition);
        // gradual sound modification should start after end end before threshold distance
        threshold = startDistance * 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // this will gradually influence the sound in dependancy of
        // the player's position on the background
        ChangeBackgroundMusic();
    }

    void ChangeBackgroundMusic()
    {
        //check current distance
        distance = Vector2.Distance(player.transform.position, doorPosition);
        cameraAudioSource.spatialBlend = (startDistance / distance );
    }
}
