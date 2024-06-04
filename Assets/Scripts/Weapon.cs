using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

// Shooting code referenced from: Brackeys
// Reference: https://www.youtube.com/watch?v=wkKsl1Mfp5M&t=200s
// and Root Games
// Reference: https://www.youtube.com/watch?v=vkKulG71Yzo

public class Weapon : MonoBehaviour
{
    // Effects and sprite rendering variables
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject impactEffect;
    public GameObject gunFizzleEffect;
    
    // Sound variables
    [SerializeField] private AudioSource shootSoundEffect;

    // Update is called once per frame
    void Update()
    {   
        // Shoot prefab bullet
        if (Input.GetButtonDown("Fire1"))
        {
            
            PrefabShoot();
            // Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }
    }

    // Prefab shoot logic function
    void PrefabShoot()
    {
        // Make gun fizzle
        Instantiate(gunFizzleEffect, firePoint.position, transform.rotation);

        // Make bullet
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        shootSoundEffect.Play();
    }

}
