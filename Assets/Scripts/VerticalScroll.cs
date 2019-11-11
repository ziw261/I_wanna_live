using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour {
    [Tooltip("Game units per second")] [SerializeField]
    private float scrollRate = 0.2f;

    public bool waterTrigger = false;
    
    
    void Update() {
        if (waterTrigger) {
            WaterUP();
        } 
    }

    private void WaterUP() {
        float yMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
    }
    
}
