using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{
    public class Script_P1_Crafter : MonoBehaviour
    {
        public bool[] CraftingPoints = new bool[3];

        public float _numberOfTrue;

        public string ResourceTag;
        //The position that the spawner has, No. = to the CrafitngPoints bool length
        public Transform Checker_1;
        public Transform Checker_2;
        public Transform Checker_3;


        //objects to spawn
        public GameObject Fuel;
        public GameObject Ammo;
        public GameObject Repair;

        private GameObject _TempObject1;
        private GameObject _TempObject2;
        private GameObject _TempObject3;

        public Transform SpawnLocation;
        
        // Start is called before the first frame update
        void Start()
        {
            ResetCrafter();
        }

        // Update is called once per frame
        void Update()
        {
            CraftingComponentChecker();



            if (Input.GetKeyDown(KeyCode.P))
            {
                
                CraftingCheck();
            }
        }

        public void ResetCrafter()
        {
            for (int i = 0; i < CraftingPoints.Length; i++)
            {
                CraftingPoints[i] = false;
            }

            Destroy(_TempObject1);
            Destroy(_TempObject2);
            Destroy(_TempObject3);
            _numberOfTrue = 0;
        }

        public void CraftingComponentChecker()
        {
            RaycastHit hit_1;
            if (Physics.Raycast(Checker_1.position, transform.TransformDirection(Vector3.up), out hit_1, 5))
            {
          
                if (hit_1.transform.tag == ResourceTag)
                {
                    CraftingPoints[0] = true;
                    _TempObject1 = hit_1.transform.gameObject;
                }
                else
                {
                    CraftingPoints[0] = false;
                    _TempObject1 = null;
                }
                Debug.DrawRay(Checker_1.position, transform.TransformDirection(Vector3.up) * 5, Color.red);
            }
            else
            {
                CraftingPoints[0] = false;
                _TempObject1 = null;
            }

            RaycastHit hit_2;
            if (Physics.Raycast(Checker_2.position, transform.TransformDirection(Vector3.up), out hit_2, 5))
            {
                if (hit_2.transform.tag == ResourceTag)
                {
                    CraftingPoints[1] = true;
                    _TempObject2 = hit_2.transform.gameObject;
                }
                else
                {
                    CraftingPoints[1] = false;
                    _TempObject2 = null;
                }
                Debug.DrawRay(Checker_2.position, transform.TransformDirection(Vector3.up) * 5, Color.red);
            }
            else
            {
                CraftingPoints[1] = false;
                _TempObject2 = null;
            }

            RaycastHit hit_3;
            if (Physics.Raycast(Checker_3.position, transform.TransformDirection(Vector3.up), out hit_3, 5))
            {
                if(hit_3.transform.tag == ResourceTag)
                {
                    CraftingPoints[2] = true;
                    _TempObject3 = hit_3.transform.gameObject;
                }
                else
                {
                    CraftingPoints[2] = false;
                    _TempObject3 = null;
                }
                
                Debug.DrawRay(Checker_3.position, transform.TransformDirection(Vector3.up) * 5, Color.red);
            }
            else
            {
                CraftingPoints[2] = false;
                _TempObject3 = null;
            }
        }
        


        //the function that must be called to craft an item
        public void CraftingCheck()
        {
            
            for (int j = 0; j < CraftingPoints.Length; j++)
            {
               
                if(CraftingPoints[j] == true)
                {
                    _numberOfTrue += 1;
                }

                if(j == CraftingPoints.Length - 1)
                {
                    Craft();
                    
                }
            }

            
        
        }

        public void Craft()
        {
            if(_numberOfTrue == 1)
            {
                // Instantiate(Repair, SpawnLocation.position, Quaternion.identity);
                Debug.Log(_numberOfTrue + " Crafted");
                ResetCrafter();
            }
            else if(_numberOfTrue == 2)
            {
                //Instantiate(Ammo, SpawnLocation.position, Quaternion.identity);
                Debug.Log(_numberOfTrue + " Crafted");
                ResetCrafter();
            }
            else if(_numberOfTrue == 3)
            {
                //Instantiate(Fuel, SpawnLocation.position, Quaternion.identity);
                Debug.Log(_numberOfTrue + " Crafted");
                ResetCrafter();
            }
            else
            {
                Debug.Log(_numberOfTrue + " This is the value of numberofTrue");
                ResetCrafter();
            }
        }
    }
}
