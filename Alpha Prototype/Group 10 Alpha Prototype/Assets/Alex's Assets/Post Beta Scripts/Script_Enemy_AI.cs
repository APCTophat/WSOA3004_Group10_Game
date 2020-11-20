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

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player2").transform;
            agent = GetComponent<NavMeshAgent>();
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
    }
}
