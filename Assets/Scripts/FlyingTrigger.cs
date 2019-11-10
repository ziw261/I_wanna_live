using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class FlyingTrigger : MonoBehaviour {

    [SerializeField] private FlyingObject flyingObject;


    private void OnTriggerEnter2D(Collider2D other) {
        // Let the object fly up. 
        flyingObject.shouldFly = true;
       
    }
}
