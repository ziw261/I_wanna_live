using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeperBlock : MonoBehaviour {

    //[SerializeField] private GameObject go;

    private void OnMouseDown() {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.enabled = true;
        Debug.Log("Clicked!");
    }
}    
