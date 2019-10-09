using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjects : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("Activated");
        sp.enabled = true;
        sp.sortingLayerName = "Foreground";

        PolygonCollider2D pg2d = gameObject.GetComponent<PolygonCollider2D>();
        pg2d.enabled = true;
    }
}
