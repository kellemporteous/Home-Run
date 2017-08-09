using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public static SoundController instance;

    AudioSource audioSource;

    public AudioClip P1Slap;
    public AudioClip P2Slap;
    public AudioClip balloonPickup;
    public AudioClip balloonThrow;
    public AudioClip enemySlap;
    public AudioClip P1Jump;
    public AudioClip P2Jump;

	// Use this for initialization
	void Start () {
        instance = this;
        audioSource = GetComponent<AudioSource>();
	}

    public void P1slap()
    {
        audioSource.PlayOneShot(P1Slap);
    }

    public void P2slap()
    {
        audioSource.PlayOneShot(P2Slap);
    }

    public void BalloonPickup()
    {
        audioSource.PlayOneShot(balloonPickup);
    }

    public void BalloonThrow()
    {
        audioSource.PlayOneShot(balloonThrow);
    }

    public void EnemySlap()
    {
        audioSource.PlayOneShot(enemySlap);
    }

    public void P1jump()
    {
        audioSource.PlayOneShot(P1Jump);
    }

    public void P2jump()
    {
        audioSource.PlayOneShot(P2Jump);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
