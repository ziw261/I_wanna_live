using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DashAbility : MonoBehaviour {
    public DashState dashState;
    public float dashTimer = 0;
    public float maxDash = 0.5f;
    public float dashSpeed = 3f;
    
    public Vector2 savedVelocity;
    
    void Update ()  {
        switch (dashState) 
        {
            case DashState.Ready:
                var isDashKeyDown = CrossPlatformInputManager.GetButtonDown("Dash");
                if(isDashKeyDown) {
                    savedVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x * dashSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 1f;
                if(dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    gameObject.GetComponent<Rigidbody2D>().velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if(dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }
}
 
public enum DashState {
    Ready,
    Dashing,
    Cooldown
}

