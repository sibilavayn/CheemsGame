using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip fire;
    public AudioSource audioSource;
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }
    void OnCollisionEnter()
    {
        audioSource.PlayOneShot(jump, 0.3F);
        audioSource.PlayOneShot(fire, 0.3f);
    }

}
