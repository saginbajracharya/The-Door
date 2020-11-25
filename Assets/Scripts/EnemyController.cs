using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public AudioSource enemyDeadAudio;
    CharacterController _controller;
    Transform target;
    GameObject Player;
    GameObject ArenaDoor1;
    GameObject Arena1Spawner;
    GameObject ArenaDoor2;
    GameObject Arena2Spawner;
    GameObject ArenaDoor3;
    GameObject Arena3Spawner;

    public int barrier1 = 100; 
    public int barrier2 = 300;
    public int barrier3 = 500; 

    int i = 0;

    [SerializeField]
    float _moveSpeed = 8.0f;

    public int scoreValue = 1;

    // Use this for initialization
    void Start()
    {
        i = 0;
        ArenaDoor1 = GameObject.FindGameObjectWithTag("ArenaDoor");
        ArenaDoor2 = GameObject.FindGameObjectWithTag("ArenaDoor2");
        ArenaDoor3 = GameObject.FindGameObjectWithTag("ArenaDoor3");

        Arena1Spawner = GameObject.FindGameObjectWithTag("Arena1Spawner");
        Arena2Spawner = GameObject.FindGameObjectWithTag("Arena2Spawner");
        Arena3Spawner = GameObject.FindGameObjectWithTag("Arena3Spawner");
        
        enemyDeadAudio = GetComponent<AudioSource>();

        Player = GameObject.FindWithTag("enemyFollowTarget"); 

        target = Player.transform;
    
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction = direction.normalized;

        Vector3 velocity = direction * _moveSpeed;

        _controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(ScoreManager.score==barrier1)
        {
            if(ArenaDoor1!=null)
            {
                Arena1Spawner.GetComponent<Spawner>().CancelInvoke();
                Destroy(ArenaDoor1);
                // ArenaDoor.SetActive(false);
            }
        }
        else if(ScoreManager.score==barrier2)
        {
            if(ArenaDoor2!=null)
            {
                Arena2Spawner.GetComponent<Spawner>().CancelInvoke();
                Destroy(ArenaDoor2);
                // ArenaDoor.SetActive(false);
            }
        }
        else if(ScoreManager.score==barrier3)
        {
            if(ArenaDoor3!=null)
            {
                Arena3Spawner.GetComponent<Spawner>().CancelInvoke();
                Destroy(ArenaDoor3);
                // ArenaDoor.SetActive(false);
            }
        }
        if(other.gameObject.tag == "Bullet")
        {
            if(gameObject.name!="Boss")
            {
                if(enemyDeadAudio!=null)
                {
                    enemyDeadAudio.Play(0);
                }
                enemyDeadAudio.Play(0);
                ScoreManager.score +=scoreValue;
                Destroy(gameObject);
            }
            else
            {
                i++;
                if(i==100)
                {
                    if(enemyDeadAudio!=null)
                    {
                        enemyDeadAudio.Play(0);
                    }
                    enemyDeadAudio.Play(0);
                    ScoreManager.score +=scoreValue;
                    Destroy(gameObject);
                    SceneManager.LoadScene(0);
                }
            }
        }
        else if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
