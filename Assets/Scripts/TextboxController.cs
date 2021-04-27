using System.Collections;
using System.Collections.Generic;
using Nvp.Tools.Events.EventBus;
using UnityEngine;
using UnityEngine.UI;

public class TextboxController : MonoBehaviour
{
    private Text textbox;
    private AudioSource click;
    private bool isClickable = false;
    private string theText;
    private int index = 0;
    private float timeLapse = 0.15f;
    private float offset;


    private void OnEnable()
    {
        textbox = gameObject.GetComponent<Text>();
        click = gameObject.GetComponent<AudioSource>();
        NvpEventBus.AddListener(GameEvent.OnTextbox, StartWriting);
    }

    private void OnDisable()
    {
        NvpEventBus.RemoveListener(GameEvent.OnTextbox, StartWriting);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartWriting(object obj)
    {
        theText = SetText();
        StartCoroutine(BuildText());
    }

    private string SetText()
    {
        return "";
    }

    private IEnumerator BuildText()
    {
        for (int i = 0; i < theText.Length; i++)
        {
            textbox.text = string.Concat(textbox.text, theText[i]);

            if (theText[i] == ',')
            {
                offset = 0.3f;
                isClickable = true;
            }
            else if (theText[i] == '.')
            {
                offset = 0.6f;
                isClickable = false;
            }
            else if (theText[i] == ' ')
            {
                isClickable = false;
            }
            else
            {
                offset = 0;
                isClickable = true;
            }

            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSeconds(timeLapse + offset);
            if (isClickable)
            {
                click.Play();
            }
        }
        NvpEventBus.DispatchEvent(GameEvent.OnTextFinished, null);
    }
}
