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

        StartCoroutine(TakeLife());

        /*
        if (playerLives > 1) {
            StartCoroutine(TakeLife());
        } else {
            StartCoroutine(ResetGameSession());
        }
        */
    }


    public int ReturnScore() {
        return score;
    }

    public void ZeroScore() {
        score = 0;
    }

    
    
    IEnumerator TakeLife() {
        yield return new WaitForSeconds(2f);
        score = 0;
        AddToScore(0);
        playerLives--;
        livesText.text = playerLives.ToString();
        FindObjectOfType<Player>().isReversed = false;
        
        // To prevent infinite death
        Physics2D.gravity = new Vector2(0, -9.8f*50);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ResetGameSession() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
