using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Alex.Carvalho
{
    public class Beta_Script_Crafting : MonoBehaviour
    {
        #region Variables realated to the identity of the crafter
        public enum CraftingType
        {
            Ammo = 0,
            Fuel = 1,
            Upgrade = 2
        }

        public CraftingType _craftingType;

        [Tooltip("The prefab of the Raw Reasource for the type you want the crafter to recieve")]
        public GameObject RawReasource;
        [Tooltip("The prefab of the Refined Reasource for the type you want the crafter to produce")]
        public GameObject RefinedReasource;
        #endregion

        #region variables realted to crafting
        [Tooltip("The amount of time raw reasources needs to be fed into the crafter to make a refined resource")]
        public float _craftingTime;
        [Tooltip("The amount a new reasource has been crafted")]
        public float _craftingAmount;
        [Tooltip("The rate at which the crafting takes place at")]
        public float _craftingRate;
        [Tooltip("The position of the output of the crafter")]
        public Transform CraftingOuputPos;
        [Tooltip("The off set the refined resources will spawn at")]
        public Vector3 SpawnOffset;
        [Tooltip("The name of the child object of the raw reasource designed for this space")]
        public string RawReasourceType;
        [Tooltip("A bool to check if there is already a refined object on the spawner")]
        public bool canSpawn;
        [Tooltip("This is the output gameobject for the crafter called _Crafting Output Collider")]
        public GameObject CraftingOutput;
        #endregion

        #region Crafting motion variables
        public GameObject gear1;
        public GameObject gear2;
        public GameObject piston1;
        public GameObject piston2;
        public float timer1;
        public float timer2;
        public float timer3;
        public bool isUp = false;
        #endregion

        #region Variables for the Ui
        public Image CompletionBar;
        #endregion

        private void Start()
        {
            CompletionBar = GetComponentInChildren<Image>();
        }

        private void Update()
        {
            UpdateUI();
            SpawningResource();
        }

        #region Crafting the reasource method          

        public void CraftingRefinedResource(string childName)
        {
            if(childName == RawReasourceType)
            {
                //Increasing the crafting Time
                _craftingAmount += _craftingRate * Time.deltaTime;
                
                //Moving gears and pistons
                gear1.transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);
                gear2.transform.Rotate(new Vector3(0f, 0f, -100f) * Time.deltaTime);

            //****************************************
            //pistons
            if (timer2 >= 0 & isUp == false)
            {
                piston1.transform.Translate(new Vector3(0f, 1f, 0f) * Time.deltaTime);
                piston2.transform.Translate(new Vector3(0f, -1f, 0f) * Time.deltaTime);
                timer2 -= Time.deltaTime;
                if (timer2 <= 0)
                {
                    isUp = true;
                }
            }

            if (timer2 <= timer3 & isUp == true)
            {
                piston1.transform.Translate(new Vector3(0f, -1f, 0f) * Time.deltaTime);
                piston2.transform.Translate(new Vector3(0f, 1f, 0f) * Time.deltaTime);
                timer2 += Time.deltaTime;
                if (timer2 >= timer3)
                {
                    isUp = false;
                }
            }
            //****************************************


            }
           
        }

        public void SpawningResource()
        {
            //Spawn the reasource && caps it at the max amount
            if (_craftingAmount >= _craftingTime)
            {
                _craftingAmount = _craftingTime;
                CraftingOutput.GetComponent<Beta_Output_Collider_Script>().DetectBlock();
                bool canSpawn = CraftingOutput.GetComponent<Beta_Output_Collider_Script>()._canSpawn;
                if (canSpawn)
                {
                    Instantiate(RefinedReasource, CraftingOuputPos.position + SpawnOffset, Quaternion.identity);
                    //Reset the crafting time
                    _craftingAmount = 0;
                    //Stopping gears and pistons//
                    gear1.transform.Rotate(new Vector3(0f, 0f, 0f) * Time.deltaTime);
                    gear2.transform.Rotate(new Vector3(0f, 0f, 0f) * Time.deltaTime);
                }

            }

        }
        #endregion

        #region Update the UI Region

        public void UpdateUI()
        {
            CompletionBar.fillAmount = _craftingAmount / _craftingTime;
        }
        #endregion
    }
}
