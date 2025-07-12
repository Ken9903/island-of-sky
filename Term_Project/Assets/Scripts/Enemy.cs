using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Player player;
    public Animator player_Ani;
    public Basic_Attack basic_Attack;
    public GameDirector gameDirector;
    public int enemy_Hp = 100;
    Vector3 enemyPos;
    public GameObject particle_Die;
    public GameObject particle_Skill;
    private string coll_Tag;

    public GameObject attack_Start;
    public GameObject player_Attack;

    public Text text_Skill;

    public bool fight;

    public string monster;

    void Update()
    {
       if(enemy_Hp <= 0)
        {
            GetComponent<AudioSource>().Play(); 
            gameDirector.score++;   

            enemyPos = this.transform.position;                 
            enemyPos.x = this.transform.position.x - 103; 
            enemy_Hp = 100; 

            Instantiate(particle_Die, this.transform.position,this.transform.rotation);

            this.transform.position = enemyPos; 
            fight = false;                                  

            player_Ani.SetBool("kill_Enemy", true); 
            player.move = true; 
        }
       if(fight && basic_Attack.skill_Count >=1)
        {
            GetComponent<AudioSource>().Play(); 
            text_Skill.text = basic_Attack.skill_Count + "CUBE!!";
            fight = false;

            player_Attack.transform.position = attack_Start.transform.position; 

            gameDirector.score++; 

            enemyPos = this.transform.position;
            enemyPos.x = this.transform.position.x - 103; 

            Instantiate(particle_Die, this.transform.position, this.transform.rotation); 
            this.transform.position = enemyPos; 
            enemy_Hp = 100;  
            player.spped = 35f; 

            particle_Skill.GetComponent<ParticleSystem>().Play();
            basic_Attack.skill_Count -= 1;
            player.move = true;

            player_Ani.SetBool("attack_Pre", false);
            player_Ani.SetBool("kill_Enemy", true);    
            player_Ani.Play("Cha_Attack");  
        } 
       
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player" && basic_Attack.skill_Count <= 0)
        {
            text_Skill.text = "";   

            coll_Tag = other.gameObject.tag;
            player.move = false;  

            player_Ani.SetBool("attack_Pre", true); 

            particle_Skill.GetComponent<ParticleSystem>().Stop();
            basic_Attack.enemy = GameObject.Find(this.gameObject.name);

            fight = true;

            player.spped = 15f; 
        }
        else if(other.gameObject.tag == "Player" && basic_Attack.skill_Count >= 1) 
        {
            GetComponent<AudioSource>().Play(); 

            player_Ani.SetBool("kill_Enemy", true);
            player_Ani.SetBool("attack_Pre", false);
            player_Ani.Play("Cha_Attack"); 

            player_Attack.transform.position = attack_Start.transform.position; 
            gameDirector.score++;  
            enemyPos = this.transform.position;
            enemyPos.x = this.transform.position.x - 103; 

            Instantiate(particle_Die, this.transform.position, this.transform.rotation);

            this.transform.position = enemyPos; 

            basic_Attack.skill_Count -= 1; 
            
           
        }
    }
}

