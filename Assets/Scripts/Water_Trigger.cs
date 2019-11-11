using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Water_Trigger : MonoBehaviour {

    [SerializeField] private VerticalScroll vs;
    private bool shouldDestroy = false;
    private bool label = false;
    
    private void OnTriggerEnter2D(Collider2D other) {
        shouldDestroy = true;
        label = true;
    }

    private void Update() {

        if (label) {
            vs.waterTrigger = true;
        }
        
        if (shouldDestroy) {
           
            StartCoroutine(Destroy());
        }
    }
    
    IEnumerator Destroy() {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
