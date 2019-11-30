using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeperBlock : MonoBehaviour {

    public bool isBomb = false;
    public Sprite exchangeSprite;

    private bool isOpened = false;
    private bool isMarked = false;
    private Sprite oldSprite = null;
    private void Start() {
        isOpened = GetComponent<SpriteRenderer>().enabled;
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
            if (!isMarked) {
                isOpened = true;
                SpriteRenderer sp = GetComponent<SpriteRenderer>();
                if (isBomb) {
                    sp.color = new Color(255, 0, 0);
                }

                sp.enabled = true;
                //Debug.Log("Clicked!");
                if (isBomb) {
                    FindObjectOfType<Player>().instantDie();
                }
            } else {
                isOpened = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = oldSprite;
                if (!isBomb) {
                    transform.localScale = new Vector3(1.5f, 0.75f, 1f);
                } else {
                    transform.localScale = new Vector3(0.6f, 0.6f, 1f);
                    gameObject.GetComponent<SpriteRenderer>().color  = new Color(255f, 0f, 0f);
                    FindObjectOfType<Player>().instantDie();
                }
            }
        } else if(Input.GetMouseButtonDown(1)) {
            if (isOpened) {
                return;
            }

            if (!isMarked) {
                Vector3 temp = transform.localScale;
                oldSprite = gameObject.GetComponent<SpriteRenderer>().sprite; 
                gameObject.GetComponent<SpriteRenderer>().sprite = exchangeSprite;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                transform.localScale = new Vector3((0.64f),(0.64f),1f);
                isMarked = true;
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,0,0);
            } else {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = oldSprite;
                if (!isBomb) {
                    transform.localScale = new Vector3(1.5f, 0.75f, 1f);
                }

                isMarked = false;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other == FindObjectOfType<Player>().GetComponent<Collider2D>()) {
            if (isBomb) {
                FindObjectOfType<Player>().instantDie();
            }

        }
    }
}    
