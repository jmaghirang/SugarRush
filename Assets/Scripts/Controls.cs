using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Animator attackingAnimation;
    private AudioSource audioSource;
    public AudioClip keyPressSound;

    // Start is called before the first frame update
    void Start()
    {
        attackingAnimation = GetComponent<Animator>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = keyPressSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            attackingAnimation.Play("Attack01_SwordAndShiled");
            audioSource.Play();
        }

        if (Input.GetKeyDown("z"))
        {
            attackingAnimation.Play("DefendHit_SwordAndShield");
            audioSource.Play();
        }
    }
}
