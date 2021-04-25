using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Nvp.Tools.Events.EventBus;

public class DoorTransition : MonoBehaviour
{
    AudioSource myAudioSource; 
    [SerializeField] AudioClip doorSound;
    Animator myAnimator;
    int iCount;

    private void OnEnable()
    {
        NvpEventBus.AddListener(GameEvent.OnTextFinished, TextFinished);
    }

    private void OnDisable()
    {
        NvpEventBus.RemoveListener(GameEvent.OnTextFinished, TextFinished);
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FishEntersDoor();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            NvpEventBus.DispatchEvent(GameEvent.OnTextbox, null);            
        }
    }

    void TextFinished(object obj)
    {
        if (FindObjectOfType<FishyController>().fishEscapeDoor)
        {
            StartCoroutine(FromIntrotoLevel1());
            Time.timeScale = 0.2f;
        }
    }

    IEnumerator FromIntrotoLevel1()
    {
        yield return new WaitForSeconds(0.5f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1f;
    }

    void FishEntersDoor()
    {
        if (iCount >= 1)
        { return; }
        else if (FindObjectOfType<FishyController>().fishEscapeDoor) // is fishy entering the door?
        {
                myAudioSource.PlayOneShot(doorSound, 1f);
                myAnimator.SetBool("TransitionOpenDoor", true);
                iCount++;
        }
        else { return; }
    }

}
