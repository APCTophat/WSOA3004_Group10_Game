using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{
    public class Script_Outside_UI : MonoBehaviour
    {
        public GameObject Panel;
        public GameObject GameManager;
        
        void Update()
        {
            if(GameManager.GetComponent<Script_Player_Scene_Manager>()._PlayerStateInt == 0)
            {
                Debug.Log("Outside");
                Panel.SetActive(true);
            }
            else
            {
                Debug.Log("Inside");
                Panel.SetActive(false);
            }
        }
    }
}
