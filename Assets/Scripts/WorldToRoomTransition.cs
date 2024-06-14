using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] GameObject fadeInPanel;
    [SerializeField] GameObject fadeOutPanel;
    [SerializeField] float fadeWait;

    [SerializeField] Vector2 room1;
    [SerializeField] Vector2 room2;

    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            // It makes a duplicate of "fadeInPanel" and place it at the starting position with no rotation.
             Destroy(panel, 1);
        }
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("Room1") == 1)
        {
            PlayerMove.instance.transform.position = room1;

            PlayerPrefs.SetInt("Room1", 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            StartCoroutine(FadeCo());
        }
    }
    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
         Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }

        yield return new WaitForSeconds(fadeWait);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone) 
        {
          yield return null;
        }
        //This code loads a new scene in a game asynchronously, which means it won't freeze the game while loading. It keeps checking if the loading operation is complete using a loop, and waits until the loading is finished before moving on.
    }
}
