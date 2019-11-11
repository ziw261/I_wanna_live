using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Trigger : MonoBehaviour {

    [SerializeField] private GameObject go;
    [SerializeField] private float waitTime = 2f;
    private bool stateSwitch = false;
    private bool shouldDestroy = false;
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        stateSwitch = true;
        shouldDestroy = true;
    }
    

    private void Update() {
        activateSwitch();
        if (shouldDestroy) {
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(waitTime);
        //shouldTurnOff = true;
        //shouldTurnOn = false;
        stateSwitch = false;
    }

    IEnumerator Destroy() {
        yield return new WaitForSeconds(waitTime + 0.1f);
        Destroy(gameObject);
    }
    

    private void activateSwitch() {
        if (stateSwitch) {
            go.SetActive(true);
            StartCoroutine(Wait());
        } else {
            go.SetActive(false);
        }
    }

}
