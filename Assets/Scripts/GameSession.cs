using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    [SerializeField] private int playerLives = 3;
    [SerializeField] private int score = 0;

    [SerializeField] private Text livesText;
    [SerializeField] private Text scoreText;
    
    //Singleton Pattern for GameSession
    private void Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    
    // Start is called before the first frame update
    void Start() {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    
    public void AddToScore(int value) {
        score += value;
        scoreText.text = score.ToString();
    }
    
    public void ProcessPlayerDeath() {
        if (playerLives > 1) {
            StartCoroutine(TakeLife());
            
        } else {
            StartCoroutine(ResetGameSession());
        }
    }

    
    
    IEnumerator TakeLife() {
        yield return new WaitForSeconds(2f);
        playerLives--;
        livesText.text = playerLives.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ResetGameSession() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
