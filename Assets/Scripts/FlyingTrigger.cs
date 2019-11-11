using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Object = UnityEngine.Object;

public class FlyingTrigger : MonoBehaviour {

    [SerializeField] private FlyingObject flyingObject;
    private bool shouldDestroy = false;



    private void OnTriggerEnter2D(Collider2D other) {
        // Let the object fly up. 
        shouldDestroy = true;
    }
    
    IEnumerator Destroy() {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void Update() {
        if (shouldDestroy) {
            flyingObject.shouldFly = true;
            StartCoroutine(Destroy());
        }
    }
}
