﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour {

    public bool shouldFly = false;
    [SerializeField] private float flyingSpeed = 2f;
    [SerializeField] private float waitTimeToResponse = 0.5f;
    
    
    public void Fly() {
        if (shouldFly) {
            StartCoroutine(Wait());
            float yMove = flyingSpeed * Time.deltaTime;
            transform.Translate(new Vector2(0f, yMove));
        }
    }

    void Update() {
        Fly();
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(waitTimeToResponse);
    }
    
}
