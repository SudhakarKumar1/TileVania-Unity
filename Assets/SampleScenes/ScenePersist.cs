using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    static int sceneIndexofLastScene = 0;
    private int startingSceneIndex;
    
    private void Awake()
    {
        int actualSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndexofLastScene == actualSceneIndex)
        {
            int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
            if (numScenePersist > 1)
            {
                Destroy(gameObject);
                Debug.Log("ScenePersist has been Destroyed due to Singleton");
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            StartCoroutine(Singleton());
        }
    }

    IEnumerator Singleton()
    {
        float yieldDuration;

        yield return new WaitForSecondsRealtime(Time.deltaTime);
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if(numScenePersist > 1)
        {
            Destroy(gameObject);
            Debug.Log("ScenePersist has been Destroyed due to Singleton");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    //Use this for Initialization
    void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndexofLastScene = SceneManager.GetActiveScene().buildIndex;
    }

    //Update is called once per frame
    void Update()
    {
        CheckIfStillInSameScene();
    }

    private void CheckIfStillInSameScene()
    {
        int actualSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(actualSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
            Debug.Log("ScenePersist has been Destroyed due to SceneChange");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
