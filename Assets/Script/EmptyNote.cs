using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmptyNote : MonoBehaviour
{
    AudioSource theAudio;
    bool canPlay = false;

    private void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canPlay == false)
        {
            if (collision.CompareTag("Note"))
            {
                theAudio.Play();
                canPlay = true;
            }
        }
    }
}
