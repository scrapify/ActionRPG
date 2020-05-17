using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using UnityEngine;
using UnityEngine.AI;
namespace RPG.Movement{

    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;
        
        NavMeshAgent navMeshAgent;

        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
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
        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<fighter>().cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            navMeshAgent.isStopped  = true;
        }

        private void UpdateAnimator()
        {
            Vector3 Velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(Velocity);
            float Speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", Speed);

        }
    }


}
