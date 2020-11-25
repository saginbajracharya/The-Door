using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public float destroyTime=3.5f;
    public GameObject particleEffectWalls;
    public GameObject particleEffectGround;
    public GameObject particleEffectEnemy;

    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall" || other.gameObject.tag == "ArenaDoor" || other.gameObject.tag == "ArenaDoor2" || other.gameObject.tag == "ArenaDoor3")
        {
            Instantiate(particleEffectWalls,transform.position, transform.rotation);
        }
        else if(other.gameObject.tag == "Enemy")
        {
            Instantiate(particleEffectEnemy,transform.position, transform.rotation);
        }
        else if(other.gameObject.tag == "Ground")
        {
            Instantiate(particleEffectGround,transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
