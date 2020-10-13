using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Alex.Carvalho
{

    public class Script_Objective_Manager : MonoBehaviour
    {
        public float OnGoingTime;
        public Text TimeDisplay;
        public float Score;



        public int ObjectiveListLength;
        public List<GameObject> ObjectiveList = new List<GameObject>();
        public int TempListLength;
        public List<GameObject> TempList = new List<GameObject>();
        
        void Start()
        {
            ResetList();   
        }

        
        void Update()
        {
            CheckForWinCondition();
           
        }


        public void CheckForWinCondition()
        {
            if (Score == ObjectiveListLength)
            {
               
            }

            if(Score != ObjectiveListLength)
            {
                OnGoingTime += Time.deltaTime;                
                float Min = Mathf.FloorToInt(OnGoingTime / 60);
                float Sec = Mathf.FloorToInt(OnGoingTime % 60);
                float Mil = (OnGoingTime % 1) * 1000;
                TimeDisplay.text = string.Format("{0:00}:{1:00}:{2:000}", Min, Sec, Mil);    
            }
        }

        public void UpdateScore()
        {
            Score += 1;
        }
        public void SpawnNextObjective(Transform _transform)
        {
                for (int i = 0; i < TempListLength; i++)
                {

                    if (TempList[i].transform.position == _transform.position)
                    {
                       
                        TempList.Remove(TempList[i]);
                        TempListLength = TempList.Count;
                        if (TempListLength >= 1)
                        {
                            int TempRandomNum = Random.Range(0, TempListLength);
                            TempList[TempRandomNum].SetActive(true);
                        }
                       return;
                    }
                }
            
        }
            

        public void ResetList()
        {
            TempList.AddRange(ObjectiveList);
            ObjectiveListLength = ObjectiveList.Count;
            TempListLength = ObjectiveListLength;
        }
    }
}
