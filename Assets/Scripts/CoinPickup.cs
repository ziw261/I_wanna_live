using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private AudioClip coinPickUpSFX;
    [SerializeField] private int pointsForCoinPickup = 100;
    
    private void OnTriggerEnter2D(Collider2D other) {
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
