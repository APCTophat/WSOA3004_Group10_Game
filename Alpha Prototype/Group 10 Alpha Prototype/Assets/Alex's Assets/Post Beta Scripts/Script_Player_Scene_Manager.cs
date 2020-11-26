using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{
    public class Script_Player_Scene_Manager : MonoBehaviour
    {

        public enum PlayerState
        {
            OutsideEnviroment = 0,
            InsideEnviroment = 1
        }
        public PlayerState _PlayerState;
        public int _PlayerStateInt;

        #region ChangePlayerSettings
        //OutsidePlayer
        public GameObject OutsideCamera;

        //InsidePlayer
        public GameObject InsideCamera;
        #endregion

        public void Start()
        {
            _PlayerState = PlayerState.OutsideEnviroment;
        }

        public void Update()
        {
            InsidePlayerSettings();
            OutsidePlayerSettings();
            _PlayerStateInt = (int)_PlayerState;
        }

        public void ChangeToInside()
        {
            _PlayerState = PlayerState.InsideEnviroment;
        }

        public void ChangeToOutside()
        {
            _PlayerState = PlayerState.OutsideEnviroment;
        }

        public void InsidePlayerSettings()
        {
            if(_PlayerState == PlayerState.InsideEnviroment)
            {
                InsideCamera.SetActive(true);
                OutsideCamera.SetActive(false);
            }
        }

        public void OutsidePlayerSettings()
        {
            if (_PlayerState == PlayerState.OutsideEnviroment)
            {
                InsideCamera.SetActive(false);
                OutsideCamera.SetActive(true);
            }
        }
    }
}
