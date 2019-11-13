using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeperBlock : MonoBehaviour {

    public bool isBomb = false;
    public Sprite exchangeSprite;

    private void Update() {
       
    }

    /*
    private void OnMouseDown() {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.enabled = true;
        //Debug.Log("Clicked!");
        if (isBomb) {
            FindObjectOfType<Player>().instantDie();
        }
    }
    */

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            SpriteRenderer sp = GetComponent<SpriteRenderer>();
            if (isBomb) {
                sp.color = new Color(255,0,0);
            }
            sp.enabled = true;
            //Debug.Log("Clicked!");
            if (isBomb) {
                FindObjectOfType<Player>().instantDie();
            }
        } else if(Input.GetMouseButtonDown(1)){
            gameObject.GetComponent<SpriteRenderer>().sprite = exchangeSprite;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            transform.localScale = new Vector3(0.5f,0.5f,1f);
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other == FindObjectOfType<Player>().GetComponent<Collider2D>()) {
            FindObjectOfType<Player>().instantDie();
        }
    }
}    
