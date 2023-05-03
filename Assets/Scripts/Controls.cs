using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Animator attackingAnimation;
    private AudioSource audioSource;
    private AudioSource audioSource2;
    public AudioClip keyPressSound;
    public AudioClip keyPressSound2;

    // Start is called before the first frame update
    void Start()
    {
        attackingAnimation = GetComponent<Animator>();

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
            attackingAnimation.Play("Attack01_SwordAndShiled");
            audioSource.Play();
        }

        if (Input.GetKeyDown("z"))
        {
            attackingAnimation.Play("DefendHit_SwordAndShield");
            audioSource2.Play();
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(horizontalInput * Time.deltaTime * 8f, 0f, verticalInput * Time.deltaTime * 8f);
    }
}