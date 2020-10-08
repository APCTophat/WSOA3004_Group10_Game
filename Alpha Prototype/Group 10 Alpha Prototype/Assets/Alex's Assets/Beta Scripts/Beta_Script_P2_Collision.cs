﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{
    public class Beta_Script_P2_Collision : MonoBehaviour
    {
        public GameObject GameManger;

        public string ResourceTag;
        public string ObstacleTag;
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
            
        }
    }
}
