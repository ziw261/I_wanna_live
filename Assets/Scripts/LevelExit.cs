using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField] private float LevelLoadDelay = 2f;
    [SerializeField] private float LevelExitSlowMoFactor = 0.2f;
    

    public void Update() {
        // IMPORTANT: Change the build index for future release.
        LevelExitAppear(1,3);
        LevelExitAppear(2,2);
    }


    private void LevelExitAppear(int buildIndex, int requiredScore) {
        if (SceneManager.GetActiveScene().buildIndex == buildIndex) {
            SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
            BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();

            if (FindObjectOfType<GameSession>().ReturnScore() != requiredScore) {
                sp.enabled = false;
                bc.enabled = false;
                
            } else {
                sp.enabled = true;
                sp.sortingLayerName = "Interactable";
                bc.enabled = true;
                bc.isTrigger = true;
            }
        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(LoadNextLevel());
    }
    
    
    IEnumerator LoadNextLevel() {
        /*
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;
        */
        yield return new WaitForSeconds(0f);
        
        
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<GameSession>().ZeroScore();
        FindObjectOfType<GameSession>().AddToScore(0);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
