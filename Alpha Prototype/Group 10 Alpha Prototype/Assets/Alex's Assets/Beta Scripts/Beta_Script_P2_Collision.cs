﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{
    public class Beta_Script_P2_Collision : MonoBehaviour
    {
        public GameObject GameManger;
        public AudioClip MetalHit;

        public string ResourceTag;
        public string ObstacleTag;
        public string ObjectiveTag;
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
                var EnumValue = other.GetComponent<Beta_Script_World_Resource>()._worldResource;
                GameManger.GetComponent<Beta_Script_GameManager>().SpawnResourceP1((int)EnumValue);
                GameManger.GetComponent<Beta_Script_GameManager>().SpawnResourceP2((int)EnumValue, other.transform);
                other.gameObject.SetActive(false);
            }
           
            if(other.gameObject.tag == ObstacleTag)
            {
                var EnumValue = other.GetComponent<Beta_Script_World_Obstacles>()._challengeType;
                GameManger.GetComponent<Beta_Script_GameManager>().DecreaseHealth((int)EnumValue);
            }

            AudioManager.Instance.PlayEffects(MetalHit,0.5f);

            if(other.gameObject.tag == ObjectiveTag)
            {
                GameManger.GetComponent<Script_Objective_Manager>().SpawnNextObjective(other.transform);
                GameManger.GetComponent<Script_Objective_Manager>().UpdateScore();
                other.gameObject.SetActive(false);
            }
            
        }
    }
}
