using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Trap_Trigger : MonoBehaviour {
    [SerializeField] private Moving_Trap movTrapObj;
    private bool shouldDestroy = false;

    
    
    private void OnTriggerEnter2D(Collider2D other) {
        // Let the object fly up. 
        shouldDestroy = true;
        //Debug.Log("wtf?");
    }
    
    IEnumerator Destroy() {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void Update() {
        if (shouldDestroy) {
            movTrapObj.shouldFly = true;
            StartCoroutine(Destroy());
        }
    }
}
