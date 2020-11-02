using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Alex.Carvalho
{
    public class Script_Solar_Event : MonoBehaviour
    {

        #region EventTimer Variables
        private float TimeTillNextWave;
        public float MaxTime;
        public float MinTime;

        public Text NextWaveText;
        #endregion

        #region SolarFlare Event Variables
        public GameObject GameManager;

        public float EventDuration;
        public float EventDurationTime;
        #endregion


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CountDownTimer();
        }

        public void CallNextWave()
        {
            TimeTillNextWave = Random.Range(MinTime, MaxTime);
        }

        public void CountDownTimer()
        {
            TimeTillNextWave -= Time.deltaTime;
            NextWaveText.text = TimeTillNextWave.ToString("f2");
            if(TimeTillNextWave <= 0)
            {
                NextWaveText.text = "0";
                SolarFlare();
            }
        }

        public void SolarFlare()
        {
            EventDuration -= Time.deltaTime;
            GameManager.GetComponent<Beta_Script_GameManager>().SolarEventHealth();
            if(EventDuration <= 0)
            {
                CallNextWave();
                EventDuration = EventDurationTime;
                
            }
        }
    }
}
