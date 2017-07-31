using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   /* public Rigidbody2D rb;
    public SpriteRenderer rend;

    private GameObject idleCollider;
    private GameObject slapCollider;
    private GameObject jumpCollider;

    public float moveSpeed;

    public bool isPlayer1;

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
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

        idleCollider = transform.Find("Idle").gameObject;
        slapCollider = transform.Find("Slap").gameObject;
        jumpCollider = transform.Find("Jump").gameObject;

        slapCollider.SetActive(false);
        jumpCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            idleCollider.SetActive(true);
            slapCollider.SetActive(false);
            jumpCollider.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            idleCollider.SetActive(false);
            slapCollider.SetActive(true);
            jumpCollider.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            idleCollider.SetActive(false);
            slapCollider.SetActive(false);
            jumpCollider.SetActive(true);
        }


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
        if ((Input.GetAxis("horizontalP1") == -1f || Input.GetAxis("horizontalP2") == -1f) && transform.position.x <= right.position.x)
        {
            rend.flipX = false;


            if (isPlayer1)
                rb.transform.position = new Vector2(rb.transform.position.x + moveSpeed / 100, player.transform.position.y);
            if (!isPlayer1)
            {
                //player2.transform.position = new Vector2(player2.transform.position.x + speed / 100, player.transform.position.y); ;
            }
        }

        if ((Input.GetAxis("horizontalP1") == 1f || Input.GetAxis("horizontalP2") == 1f) && transform.position.x >= Vector2.zero)
        {
            rend.flipX = true;

            if (isPlayer1)
                playerRB.transform.position = new Vector2(playerRB.transform.position.x - (speed - 1) / 100, player.transform.position.y);
            if (!isPlayer1)

                player2.transform.position = new Vector2(player2.transform.position.x - (speed - 1) / 100, player.transform.position.y);
        }

        if ((Input.GetAxis("verticalP1") == -1f || Input.GetAxis("verticalP2") == -1f) && player.transform.position.y <= up.position.y)
        {


            if (isPlayer1)
                playerRB.transform.position = new Vector2(playerRB.transform.position.x, player.transform.position.y + speed / 200);
            if (!isPlayer1)

                player2.transform.position = new Vector2(player2.transform.position.x, player.transform.position.y + speed / 200);
        }

        if ((Input.GetAxis("verticalP1") == 1f || Input.GetAxis("verticalP2") == 1f) && player.transform.position.y >= down.position.y)
        {
            if (isPlayer1)
                playerRB.transform.position = new Vector2(playerRB.transform.position.x, player.transform.position.y - speed / 200);
            if (!isPlayer1)

                player2.transform.position = new Vector2(player2.transform.position.x, player.transform.position.y - speed / 200);
        }

    }*/
}
