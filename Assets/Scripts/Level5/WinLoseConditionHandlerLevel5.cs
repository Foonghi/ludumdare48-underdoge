using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseConditionHandlerLevel5 : MonoBehaviour
{
    [SerializeField] GameObject slipScenePlayer;
    [SerializeField] GameObject fishPlayer;
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
        GameObject slippy = Instantiate(slipScenePlayer, slipScenePlayer.transform.position, slipScenePlayer.transform.rotation) as GameObject;
        FindObjectOfType<DeleteLight>().DestroyMe();
        yield return new WaitForSeconds(3f);
        GameObject Player = Instantiate(fishPlayer, fishPlayer.transform.position, fishPlayer.transform.rotation) as GameObject;
    }

    public void PlayerLoseReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);