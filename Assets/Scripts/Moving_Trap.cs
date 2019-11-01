using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Trap : MonoBehaviour
{
    [SerializeField] private float waitTimeToChangeDir = 5f;
    [SerializeField] private float moveSpeed = 0.5f;
    private bool changeDirection = false;
    
    
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update() {
        Mov();
    }
    
    IEnumerator Wait() {
        //Debug.Log("Got here once");
        yield return new WaitForSeconds(waitTimeToChangeDir);
        changeDirection = !changeDirection;
        StartCoroutine(Wait());
    }

    private void Mov() {
        if (changeDirection == false) {
            float yMove = moveSpeed * Time.deltaTime;
            transform.Translate(new Vector2(0f, yMove));
        } else {
            float yMove = moveSpeed * Time.deltaTime;
            transform.Translate(new Vector2(0f, -yMove));
        }
    }
}
