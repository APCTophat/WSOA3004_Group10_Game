using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{

    public class Beta_Script_World_Obstacles : MonoBehaviour
    {
        public enum ChallengeType
        {
            Not = 0,
            Obstacle = 1,
            Enemy = 2
        }
        public ChallengeType _challengeType;

        public float Health;
        public float moveIntervals;
        public float moveSpeed;

        public Vector3 StartPos;
        public Vector3 TargetPos;

        public GameObject gun;
        
        void Start()
        {
            gun = GameObject.Find("Gun Script Holder");
            moveIntervals = 5f;
            StartPos = transform.localPosition;
            TargetPos = transform.localPosition;
        }

       
        void Update()
        {
           
            if(Health <=0)
            {
                Destroy(gameObject);
            }
        }

      

        private void OnCollisionEnter(Collision collision)
        {
            if (_challengeType == ChallengeType.Enemy)
            {
                if (collision.gameObject.tag == "Projectile")
                {
                    float Damage = gun.GetComponent<Script_Bens_Shoot>()._bulletDamage;
                    Health -= Damage;
                }
            }
        }


    }
}
