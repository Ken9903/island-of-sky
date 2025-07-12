using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Basic_Attack : MonoBehaviour
{
    public float speed;
    private int Enhance = 1;
    private string coll_tag;

    public int player_Ad = 25; 
    public int skill_Count;

    public GameObject enemy;
    public GameObject attack_Start;
    public GameObject gameEnd;
    public GameObject pos;

    public GameObject cube0;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    public GameObject Sound;           

    public Text text_Enhance;
    public Animator player_Ani;

    int fault = 4;

    void Update()
    {
        if (enemy == null || !enemy.gameObject.GetComponent<Enemy>().fight)
        {
            return;
        } 

        if (Input.GetMouseButtonDown(0)) 
        { 
            if (coll_tag == "Attack") 
            {
                GetComponent<AudioSource>().Play();
                Enhance = 1; 
                text_Enhance.text = ""; 

                if(player_Ad == 25)
                {
                    if(fault ==4)
                    {
                        fault--;
                        Destroy(cube3);
                    }else if(fault == 3)
                    {
                        fault--;
                        Destroy(cube2);
                    }
                    else if (fault == 2)
                    {
                        fault--;
                        Destroy(cube1);
                    }
                    else if (fault == 1)
                    {
                        fault--;
                        Destroy(cube0);
                        Destroy(this.gameObject);
                        GameEnd();
                    }
                } 

                coll_tag = "null"; 
                this.transform.position = attack_Start.transform.position;
                speed = -0.6f;
                Debug.Log("공격");

                if (player_Ad <= 100) 
                {              
                    enemy.gameObject.GetComponent<Enemy>().enemy_Hp -= player_Ad;
                    player_Ani.SetBool("attack_Pre", false);

                    if (enemy.gameObject.GetComponent<Enemy>().enemy_Hp > 0)
                    {
                        player_Ani.SetBool("kill_Enemy", false)
                    } 
                    player_Ani.Play("Cha_Attack");
                    player_Ad = 25;  
                    Debug.Log(enemy.gameObject.GetComponent<Enemy>().enemy_Hp);
                }
                else
                {
                    skill_Count = player_Ad / 100;
                    Debug.Log(skill_Count);
                    player_Ad = 25;
                }
            }   
            else if (coll_tag == "Enhance") 
            {
                Sound.GetComponent<AudioSource>().Play();
                coll_tag = "null"; 
                if(speed > 0) 
                {
                    speed = speed * -1;
                }

                this.transform.position = attack_Start.transform.position; 
                Debug.Log("Enhance");
                Enhance++; 
                text_Enhance.text = "X" + Enhance; 
                player_Ad = player_Ad * 2; 

                if(player_Ad <=100) 
                {
                    speed -= 0.15f;  
                    
                }else  
                {
                    speed -= 0.3f; 
                }
                
                Debug.Log(player_Ad);
            }
            else if (coll_tag == "null" || coll_tag == "Edge") 
            {
                coll_tag = "null"; 
                this.transform.position = attack_Start.transform.position;  
                Debug.Log("실패");

                GameEnd(); 
                this.speed = 0;
                player_Ad = 25;
            }

        }     
        this.transform.Translate(new Vector3(speed * Time.deltaTime , 0, 0));      
    }

    private void OnTriggerEnter(Collider other)
    {
        coll_tag = other.gameObject.tag; 

        if (other.gameObject.tag == "Edge") 
        {
            speed = speed * (-1);
        }  
    }

    public void GameEnd()
    {
        gameEnd.transform.position = pos.transform.position; 

    }
}
