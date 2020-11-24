using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{
    public class Beta_Script_P2_Collision : MonoBehaviour
    {
        public GameObject GameManger;
        public AudioClip MetalHit;
        public AudioClip ObjectiveHit;
        public AudioClip ResourceHit;
        public AudioClip EnemyHit;
        public AudioClip BulletHit;

        public string ResourceTag;
        public string ObstacleTag;
        public string ObjectiveTag;
        public string EnemyTag;
        void Start()
        {
            GameManger = GameObject.FindGameObjectWithTag("GameController");
        }

        
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == ResourceTag)
            {
               //var EnumValue = other.GetComponent<Beta_Script_World_Resource>()._worldResource;
                GameManger.GetComponent<Beta_Script_GameManager>().SpawnResourceInsidePlayer();
                GameManger.GetComponent<Beta_Script_GameManager>().SpawnResourceOutsidePlayer(other.transform);
                other.gameObject.SetActive(false);

                //sound//
                AudioManager.Instance.PlayEffects(ResourceHit, 0.5f);
            }
           
            if(other.gameObject.tag == ObstacleTag)
            {
                var EnumValue = other.GetComponent<Beta_Script_World_Obstacles>()._challengeType;
                GameManger.GetComponent<Beta_Script_GameManager>().DecreaseHealth((int)EnumValue);
                GameManger.GetComponent<Script_Maintenence_Manager>().BreakAnObject();
                //sound//
                AudioManager.Instance.PlayEffects(MetalHit, 0.5f);
                
            }

            

            if(other.gameObject.tag == ObjectiveTag)
            {
                GameManger.GetComponent<Script_Objective_Manager>().SpawnNextObjective(other.transform);
                GameManger.GetComponent<Script_Objective_Manager>().UpdateScore();
                other.gameObject.SetActive(false);
                //sound//
                AudioManager.Instance.PlayEffects(ObjectiveHit, 0.5f);
            }

            if (other.transform.tag == "Enemy")
            {
                Debug.Log("Collieded with the enemy");
            }
           

        }


        private void OnCollisionEnter(Collision collision)
        {

            if (collision.transform.tag == "Projectile")
            {
                GameManger.GetComponent<Beta_Script_GameManager>().DecreaseHealth(2);
                GameManger.GetComponent<Script_Maintenence_Manager>().BreakAnObject();
                //sound
                AudioManager.Instance.PlayEffects(BulletHit, 0.5f);
            }

            if (collision.transform.tag == "Enemy")
            {
                //AudioManager.Instance.PlayEffects(EnemyHit, 0.5f);
                Debug.Log("Collieded with the enemy");
            }
        }

    }
}
