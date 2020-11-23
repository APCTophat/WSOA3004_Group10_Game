using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.Carvalho
{
    public class Moveable_P1_Camera : MonoBehaviour
    {
        [Tooltip("The target the camera will follow")]
        public Transform FollowTarget;
        [Tooltip("The Vector postiion of the top ")]
        public Vector3 TopLeftCorner;
        public Vector3 BottomRightCorner;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(FollowTarget.position.x, transform.position.y, FollowTarget.position.z);
        }
    }
}
