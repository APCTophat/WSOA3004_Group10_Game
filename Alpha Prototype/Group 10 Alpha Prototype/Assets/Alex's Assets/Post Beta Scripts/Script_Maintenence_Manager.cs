using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{

    public class Script_Maintenence_Manager : MonoBehaviour
    {
        #region public Variables
        //Timer related variables
        [Tooltip("The intervals in which each machine turns off to see if they should be active")]
        public float IntervalReset;
        private float tempfloat;

        //Engine Related Variables
        public bool EngineActive;
        public bool EngineWorking;

        //Turret Related Variables
        public bool TurretActive;
        public bool TurretWorking;

        //Minimap Related variables 
        public bool minimapActive;
        public GameObject Minimap;

        //SolarEventTimre Related Variables
        public bool EventTimerActive;
        public GameObject EventTimerObject;

        //Warning System Related Variables
        public bool WarningSystemActive;
        public GameObject WarningObject;
        #endregion


        #region Variables related to breaking Objects
        public float ChanceToBreak;
        public int DroneStateTracker;
        public int MaintenceObjectsNo;
        public GameObject[] MaintenceObjects;
        public bool[] WorkingObjects;
        public GameObject GameManager;
        #endregion
        void Start()
        {
            tempfloat = IntervalReset;
            DroneStateTracker = MaintenceObjectsNo;
          
        }

        void Update()
        {
            UpdateTheFunctions();
            Turneverythingoff();
            CheckIfAllisWorking();

            if (Input.GetKeyDown(KeyCode.B))
            {
                BreakAnObject();
            }
        }

        public void Turneverythingoff()
        {
            tempfloat -= Time.deltaTime;
            if(tempfloat < 0)
            {
                EngineActive = false;
                TurretActive = false;
                minimapActive = false;
                EventTimerActive = false;
                WarningSystemActive = false;
                tempfloat = IntervalReset;
            }
        }
        #region MethodsCalledByObjects
        public void EngineFunction()
        {
            EngineActive = true;
        }

        public void TurretFunction()
        {
            TurretActive = true;
        }

        public void MinimapFunction()
        {
            minimapActive = true;
        }

        public void EventTimerFunction()
        {
            EventTimerActive = true;
        }

        public void WarningFunction()
        {
            WarningSystemActive = true;
        }
        #endregion

        public void UpdateTheFunctions()
        {
            //If the engine is active this means that the outside drone can move, else the outside drone cannot move is vulnerable
            if (EngineActive)
            {
                EngineWorking = true;
            }
            else
            {
                EngineWorking = false;
            }

            //If the turret is active this means that the outside drone can shoot, else they can't shoot
            if (TurretActive)
            {
                TurretWorking = true;
            }
            else
            {
                TurretWorking = false;
            }

            //If the minimap is active then the minimap will display, else it won't display
            if(minimapActive)
            {
                Minimap.SetActive(true);
            }
            else
            {
                Minimap.SetActive(false);
            }

            //If the event Timer is active then the countdown to the next solar event will show, else it won't show
            if (EventTimerActive)
            {
                //EventTimerObject.SetActive(true);
            }
            else
            {
                //EventTimerObject.SetActive(false);
            }

            //If the warning system is active then it will go off to notify the player an enemy is near, else it won't
            if (WarningSystemActive)
            {
               // WarningObject.SetActive(true);
            }
            else
            {
               // WarningObject.SetActive(false);
            }
        }

        public void BreakAnObject()
        {
            float temp = Random.Range(1, 101);
            
            if(ChanceToBreak >= temp)
            {
                for (int i = 4; i > -1; i--)
                {

                    if (WorkingObjects[i])
                    {
                        MaintenceObjects[i].GetComponent<Script_Maintenence_Object>().BrakeObject();
                        WorkingObjects[i] = false;
                        return;
                    }
                }
            }
        }

        public void FixAnObject(int ObjectInt)
        {
            WorkingObjects[ObjectInt -1] = true;
        }

        public void CheckIfAllisWorking() //Checks to see if all maintence objects are working, if so, tells the GM to slowly heal the drones
        {
            if(EngineActive && TurretActive && minimapActive && EventTimerActive && WarningSystemActive)
            {
                GameManager.GetComponent<Beta_Script_GameManager>().HealTheDrone();
            }
           
        }
    }
}
