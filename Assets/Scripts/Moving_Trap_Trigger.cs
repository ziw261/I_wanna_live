using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Trap_Trigger : MonoBehaviour {
    [SerializeField] private Moving_Trap movTrapObj;


    private void OnTriggerEnter2D(Collider2D other) {
        // Let the object fly up. 
        
       movTrapObj.shouldFly = true;
       
    }
}
