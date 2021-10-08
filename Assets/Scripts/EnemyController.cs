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
    public GameObject Player;
    public GameObject wall1 ;
    public GameObject wall2 ;
    public GameObject wall3 ;
    public GameObject wall4 ;
    public GameObject Arena1Spawner;
    public GameObject wall5 ;
    public GameObject wall6 ;
    public GameObject wall7 ;
    public GameObject wall8 ;
    public GameObject Arena2Spawner;
    public GameObject wall9 ;
    public GameObject wall10 ;
    public GameObject wall11 ;
    public GameObject wall12 ;
    public GameObject Arena3Spawner;
    public int barrier1 = 100; 
    public int barrier2 = 300;
    public int barrier3 = 500;
    public int scoreValue = 1;
    int i = 0;

    [SerializeField]
    float _moveSpeed = 8.0f;

    // Use this for initialization
    void Start()
    {
        i = 0;
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
          if(enemyDeadAudio!=null)
          {  
              enemyDeadAudio.Play(0);
          }
          Arena1Spawner.GetComponent<Spawner>().CancelInvoke();
          Destroy(wall1);
          Destroy(wall2);
          Destroy(wall3);
          Destroy(wall4);
          // ArenaDoor.SetActive(false);
        }
        else if(ScoreManager.score==barrier2)
        {
          if(enemyDeadAudio!=null)
          {
              enemyDeadAudio.Play(0);
          }
          Arena2Spawner.GetComponent<Spawner>().CancelInvoke();
          Destroy(wall5);
          Destroy(wall6);
          Destroy(wall7);
          Destroy(wall8);
          // ArenaDoor.SetActive(false);
        }
        else if(ScoreManager.score==barrier3)
        {
          if(enemyDeadAudio!=null)
          {
              enemyDeadAudio.Play(0);
          }
          Arena3Spawner.GetComponent<Spawner>().CancelInvoke();
          Destroy(wall9);
          Destroy(wall10);
          Destroy(wall11);
          Destroy(wall12);
          // ArenaDoor.SetActive(false);
        }
        if(other.gameObject.tag == "Bullet")
        {
            if(gameObject.name!="Boss")
            {
                if(enemyDeadAudio!=null)
                {
                    enemyDeadAudio.Play(0);
                }
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
