﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjects : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
        sp.enabled = true;
        sp.sortingLayerName = "Foreground";
    }
}
