using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Animator playerAnimation;

    private AudioSource audioSource;
    private AudioSource audioSource2;
    public AudioClip keyPressSound;
    public AudioClip keyPressSound2;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = keyPressSound;

        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.playOnAwake = false;
        audioSource2.clip = keyPressSound2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            playerAnimation.Play("Attack01_SwordAndShiled");
            audioSource.Play();
        }

        if (Input.GetKeyDown("z"))
        {
            playerAnimation.Play("DefendHit_SwordAndShield");
            audioSource2.Play();
        }

        //Player Movement

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput == -1f)
        {
            if (verticalInput == 1f)
            {
                playerAnimation.Play("MoveFWD_Battle_InPlace_SwordAndShield");
            }
            else if (verticalInput == -1f)
            {
                playerAnimation.Play("MoveBWD_Battle_InPlace_SwordAndShield");
            }
            else
            {
                playerAnimation.Play("MoveLFT_Battle_InPlace_SwordAndShield");
            }

        }
        if (horizontalInput == 1f)
        {
            if (verticalInput == 1f)
            {
                playerAnimation.Play("MoveFWD_Battle_InPlace_SwordAndShield");
            }
            else if(verticalInput == -1f)
            {
                playerAnimation.Play("MoveBWD_Battle_InPlace_SwordAndShield");
            }
            else
            {
                playerAnimation.Play("MoveRGT_Battle_InPlace_SwordAndShield");
            }
        }

        if (verticalInput == -1f)
        {
            playerAnimation.Play("MoveBWD_Battle_InPlace_SwordAndShield");
        }
        if (verticalInput == 1f)
        {
            playerAnimation.Play("MoveFWD_Battle_InPlace_SwordAndShield");
        }

        transform.position += new Vector3(horizontalInput * Time.deltaTime * 8f, 0f, verticalInput * Time.deltaTime * 8f);
    }
}