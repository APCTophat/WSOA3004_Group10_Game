﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{
    public class Beta_Script_P1_Collision : MonoBehaviour
    {
        #region public feilds
        public bool GrabHold;
        public bool Holding;

        [Tooltip("The name of the Reasource tag")]
        public string Resource;
        [Tooltip("The name of the Cell tag")]
        public string ContainerCell;
        [Tooltip("The name of the Refined Resource Tag")]
        public string RefinedResource;

    
        public float rayMaxDistance;

        public Vector3 offset;

        /*
        //Scene Transitions
        public GameObject Camera;
        public string AmmoRoom;
        public string CenterRoom;
        public string EngineRoom;
        public string UpgradeRoom;
        */
        //Map variables
        public string MapName;
        public GameObject MiniMap;
        //Audio
        public AudioClip Hold;
        public AudioClip Placedown;
        public bool NowOutside;
        public GameObject Player2;

        //Crafting
        public string CraftingName;
        public GameObject CraftingObject;
        public GameObject GameManager;

        //Repair
        public string MaintenceObjectTag;

        #endregion


        public void Update()
        {
            CheckForSceneElenemts();
        }
        void FixedUpdate()
        {
            //CheckRoom();
            //MapInteration();
            
            if (Input.GetKey(KeyCode.G))
            {
                GrabHold = true;
            }
            else
            {
                GrabHold = false;
            }

            Vector3 RayStartingPoint = transform.position - offset;
            RaycastHit hit;
            if (Physics.Raycast(RayStartingPoint, transform.TransformDirection(Vector3.forward), out hit, rayMaxDistance))
            {
                Debug.DrawRay(RayStartingPoint, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                
                if (GrabHold && hit.collider.tag == Resource || GrabHold && hit.collider.tag == ContainerCell || GrabHold && hit.collider.tag == RefinedResource)
                {
                    if (!Holding)
                    {
                        hit.collider.transform.parent = transform;
                        Holding = true;
                        AudioManager.Instance.PlayEffects(Hold, 0.5f);
                    }

                }
                else if(hit.collider.tag == Resource || hit.collider.tag == ContainerCell || hit.collider.tag == RefinedResource)
                {
                    Holding = false;
                    hit.collider.transform.parent = null;


                }

            }
        }
        /*
        public void CheckRoom()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
               
                if (hit.collider.name == AmmoRoom)
                {
                    Camera.GetComponent<Beta_Script_Camera>().UpdateEnum(0);
                }
                else if(hit.collider.name == CenterRoom )
                {
                    Camera.GetComponent<Beta_Script_Camera>().UpdateEnum(1);
                }
                else if (hit.collider.name == EngineRoom)
                {
                    Camera.GetComponent<Beta_Script_Camera>().UpdateEnum(2);
                }
                else if (hit.collider.name == UpgradeRoom)
                {
                    Camera.GetComponent<Beta_Script_Camera>().UpdateEnum(3);
                }
                else
                {
                    return;
                }
            }
        }

        public void MapInteration()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2))
            {
                if(hit.transform.name == MapName && Input.GetKey(KeyCode.T))
                {
                    MiniMap.SetActive(true);
                }
                else
                {
                   MiniMap.SetActive(false);
                }
                
            }

        }
        */
        public void CheckForSceneElenemts()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2))
            {
              
                if (hit.transform.name == CraftingName && Input.GetKeyDown(KeyCode.H))
                {
                    Debug.Log("CRAFTER HIT");
                    CraftingObject.GetComponent<Script_P1_Crafter>().CraftingCheck();
                }

                if(hit.transform.tag == "Drive")
                {

                    if (Input.GetKeyDown(KeyCode.H))
                    {
                        
                        GameManager.GetComponent<Script_Player_Scene_Manager>().ChangeToOutside();
                        //Activate correct sounds
                        NowOutside = true;
                        Player2.GetComponent<Beta_Script_P2_Movment>().NowInside = false;

                    }
                 
                }
               
            }
        }
    }
}
