using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private AudioClip coinPickUpSFX;
    [SerializeField] private int pointsForCoinPickup = 1;

    private bool hasBeenPicked = false;
    
    private void OnTriggerEnter2D(Collider2D other) {

        if (!hasBeenPicked) {
            hasBeenPicked = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            Destroy(gameObject);
        } 
        
    }
}
