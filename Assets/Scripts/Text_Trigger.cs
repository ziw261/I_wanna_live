using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Trigger : MonoBehaviour {

    [SerializeField] private GameObject go;
    [SerializeField] private float waitTime = 2f;
    private bool shouldTurnOff = false;
    private bool shouldTurnOn = false;
    private bool shouldDestroy = false;
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        shouldTurnOn = true;
        shouldDestroy = true;
    }
    

    private void Update() {
        turnoffText();
        turnonText();
        if (shouldDestroy) {
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(waitTime);
        shouldTurnOff = true;
        shouldTurnOn = false;
    }

    IEnumerator Destroy() {
        yield return new WaitForSeconds(waitTime + 0.1f);
        Destroy(gameObject);
    }


    private void turnoffText() {
        if (shouldTurnOff) {
            go.SetActive(false);
        }
    }

    private void turnonText() {
        if (shouldTurnOn) {
            go.SetActive(true);
            StartCoroutine(Wait());
        }
    }

}
