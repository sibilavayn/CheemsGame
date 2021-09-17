using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private AudioSource audioSource;
    public AudioClip fire;


    void Awake()
    {
        audioSource=GetComponent<AudioSource>();
    }
    

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot ();
            audioSource.PlayOneShot(fire);
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
