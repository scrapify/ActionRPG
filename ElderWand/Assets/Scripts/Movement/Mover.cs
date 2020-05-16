using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace RPG.Movement{

    public class Mover : MonoBehaviour
    {
        [SerializeField]
        private GameObject targetObject;


        // Start is called before the first frame update
        void Start()
        {
            //comment
        }

        // Update is called once per frame
        void Update()
        {
            //get the position of the sphere and assign to NavMesh Destination
            //GetComponent<NavMeshAgent>().destination = targetObject.transform.position;

            //Get Mousedown

            // if (Input.GetMouseButton(0))
            // {
            //     MoveCursor();
            // }

            UpdateAnimator();





        }


        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }

        private void UpdateAnimator()
        {
            Vector3 Velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(Velocity);
            float Speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", Speed);

        }
    }


}
