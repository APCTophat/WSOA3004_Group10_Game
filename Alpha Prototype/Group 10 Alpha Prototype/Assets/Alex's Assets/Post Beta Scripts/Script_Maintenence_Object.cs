using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Alex.Carvalho
{
    public class Script_Maintenence_Object : MonoBehaviour
    {

        public enum MaintenceType
        {
            none = 0,
            Engine = 1, //The Object that allows the drone to move
            Turret = 2, //The object that allows the drone to shoot
            MiniMap = 3,  //Object that shows the minimap
            EventTimer = 4,  //Object that shows the Time until the event
            Warning = 5 // Object the indicates if there is danage whilst the player is on the inside the drone
        }

        public MaintenceType ThisObject;

        public bool isWorking;

        public GameObject GameManger;

        public GameObject SmokeGenerator;

       
        private void Start()
        {
            FixObject();
            
        }

        void Update()
        {
            Functioning();
        }

        public void Functioning()
        {
            if (isWorking)
            {
                if (ThisObject == MaintenceType.none)
                {
                    Debug.Log(this.gameObject.name + " is not set to a MainteneceType");
                }
                else if (ThisObject == MaintenceType.Engine)
                {
                    GameManger.GetComponent<Script_Maintenence_Manager>().EngineFunction();
                }
                else if (ThisObject == MaintenceType.Turret)
                {
                    GameManger.GetComponent<Script_Maintenence_Manager>().TurretFunction();
                }
                else if (ThisObject == MaintenceType.MiniMap)
                {
                    GameManger.GetComponent<Script_Maintenence_Manager>().MinimapFunction();
                }
                else if (ThisObject == MaintenceType.EventTimer)
                {
                    GameManger.GetComponent<Script_Maintenence_Manager>().EventTimerFunction();
                }
                else if (ThisObject == MaintenceType.Warning)
                {
                    GameManger.GetComponent<Script_Maintenence_Manager>().WarningFunction();
                }
            }
        }

        public void BrakeObject()
        {
           
            SmokeGenerator.SetActive(true);
            isWorking = false;
           
        }

        public void Repair()
        {
            
            if (!isWorking)
            {
                FixObject();
               
            }
        }

        public void FixObject()
        {
            isWorking = true;
            SmokeGenerator.SetActive(false);
            GameManger.GetComponent<Script_Maintenence_Manager>().FixAnObject((int)ThisObject);
        }
     
    }
}
