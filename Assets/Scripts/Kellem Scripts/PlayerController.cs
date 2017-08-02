using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    public SpriteRenderer rend;


    public float moveSpeed;


    public enum PlayerState
    {
        Idle,
        Slap,
        Jump
    }

    PlayerState playerState;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update ()
    {
        PlayerBehaviour();
    }

    void FixedUpdate()
    {
        InputControls();
    }

    void PlayerBehaviour()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Slap:
                break;
            case PlayerState.Jump:
                break;
        }
    }

    void InputControls()
    {


    }
}
