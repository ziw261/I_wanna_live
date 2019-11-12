using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBorder : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Killed one");
        Destroy(other.gameObject);
    }
    
    
    
}
