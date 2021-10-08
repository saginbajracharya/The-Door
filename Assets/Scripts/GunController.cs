using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Rigidbody projectile; //bullet
    public Transform  barrelEnd; //bulletSpawner
    public float BulletSpeed=800f; //BulletSpeed
    public AudioSource gunShotAudio; //gunShotAudio
    public float canfire= 0.5f;  //time if bullet can be spawn or not 
    public float firerate = 1f; // rate of spawn bullet per sec

    void Start()
    {
        gunShotAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > canfire)
        {
            gunShotAudio.Play(0);
            canfire = Time.time + firerate;
            if(Input.GetKey(KeyCode.LeftShift))
            {
                Rigidbody projectileInstance;
                projectileInstance = Instantiate(projectile,barrelEnd.position,barrelEnd.rotation) as Rigidbody;
                projectileInstance.AddForce(barrelEnd.up*BulletSpeed*2);
            }
            else
            {
                Rigidbody projectileInstance;
                projectileInstance = Instantiate(projectile,barrelEnd.position,barrelEnd.rotation) as Rigidbody;
                projectileInstance.AddForce(barrelEnd.up*BulletSpeed);
            }
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            gunShotAudio.Play(0);
            if(Input.GetKey(KeyCode.LeftShift))
            {
                Rigidbody projectileInstance;
                projectileInstance = Instantiate(projectile,barrelEnd.position,barrelEnd.rotation) as Rigidbody;
                projectileInstance.AddForce(barrelEnd.up*BulletSpeed*2);
            }
            else
            {
                Rigidbody projectileInstance;
                projectileInstance = Instantiate(projectile,barrelEnd.position,barrelEnd.rotation) as Rigidbody;
                projectileInstance.AddForce(barrelEnd.up*BulletSpeed);
            }
        }
    }
}
