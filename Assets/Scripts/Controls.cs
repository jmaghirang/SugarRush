using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private SpriteRenderer sr;
    private AudioSource audioSource;
    public Sprite ogImage;
    public Sprite pressedImage;
    public AudioClip keyPressSound;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = keyPressSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sr.sprite = pressedImage;
            audioSource.Play();
        }

        if (Input.GetKeyUp(keyToPress))
        {
            sr.sprite = ogImage;
        }
    }
}
