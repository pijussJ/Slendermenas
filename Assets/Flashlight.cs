using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public Light light;
    public AudioSource switchSound;
    public float batteryPower = 300;
    public float time = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
            switchSound.Play();
        }

        light.enabled = isOn;
        if (isOn)
        {
            batteryPower -= time * Time.deltaTime;
        }
        if (batteryPower < 280)
        {
            InvokeRepeating("Fade", 1f, 1f);
        }

    }
    void Fade()
    {
        light.intensity -= 1f - batteryPower / 300f;
    }
}
