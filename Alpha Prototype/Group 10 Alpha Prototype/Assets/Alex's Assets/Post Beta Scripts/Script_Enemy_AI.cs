using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Alex.Carvalho
{
    public class Script_Enemy_AI : MonoBehaviour
    {
        public float AiRadius = 10;

        Transform target;
        NavMeshAgent agent;

        public Transform Gun;
        public Rigidbody Bullet;

        public float ShootInterval;
        private float ShootCountDown;

        public float BulletSpeed;

        public AudioClip gunsound;


        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player2").transform;
            agent = GetComponent<NavMeshAgent>();
            ShootCountDown = ShootInterval;
        }

        // Update is called once per frame
        void Update()
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if(distance <= AiRadius)
            {
                FollowPlayer();

                if(distance <= agent.stoppingDistance)
                {
                    FacePlayer();
                }
            }
            Shoot();
        }

        public void FacePlayer()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
        }

        private void FollowPlayer()
        {
            agent.SetDestination(target.position);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AiRadius);
        }

        public void Shoot()
        {

            RaycastHit hit;
            if (Physics.Raycast(Gun.transform.position, transform.TransformDirection(Vector3.forward), out hit, AiRadius))
            {
                Debug.DrawRay(Gun.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
               
                if (hit.transform.tag == "Player2")
                {

                    ShootCountDown -= Time.deltaTime;
                    if(ShootCountDown <= 0)
                    {
                       
                        Rigidbody fireBullet;
                        fireBullet = Instantiate(Bullet, Gun.position, Gun.rotation) as Rigidbody;
                        fireBullet.AddForce(Gun.forward * BulletSpeed);
                        ShootCountDown = ShootInterval;
                        AudioManager.Instance.PlayEffects(gunsound, 0.5f);
                    }
                 
                }
               
            }


        }
    }
}
