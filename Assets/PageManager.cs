using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public int pages;
    public AI AI;
    public Flashlight flashlight;
    public AudioSource scarySound;
    public GameObject enemy2;
    private void OnTriggerEnter(Collider other)
    {
        print("Page collected!");
        Destroy(other.gameObject);

        pages++;

        if (pages == 1)
        {
            AI.target = transform;
            scarySound.Play();
        }
        if (pages == 2)
        {
            AI.speed *= 2;
            scarySound.Play();
        }
        if (pages == 3)
        {
            AI.viewDistance *= 2;
            scarySound.Play();
        }
        
        if (pages == 4)
        {
            flashlight.batteryPower -= 30;
            scarySound.Play();
        }
        if (pages == 5)
        {
            scarySound.Play();
            enemy2.SetActive(true);
        }
    }
}
