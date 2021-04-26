using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseConditionHandlerLevel5 : MonoBehaviour
{
    [SerializeField] GameObject slipScenePlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player"))
        {
            return;
        }
        else
        {
            Destroy(collision.gameObject);
            StartCoroutine(AnimationDeathRebornAndLoadNextScen());
        }
    }

    IEnumerator AnimationDeathRebornAndLoadNextScen()
    {
        Debug.Log("Player wins!");

        GameObject slippy = Instantiate(slipScenePlayer, transform.position, transform.rotation) as GameObject;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayerLoseReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
