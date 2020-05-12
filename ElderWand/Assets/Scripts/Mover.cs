using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;

    //defineing a Ray
    Ray lastRay;

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

        if (Input.GetMouseButtonDown(0))
        {
            //Use Camera screen point to ray to case the ray
            lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            MoveCursor();

        }
        //use drawray to display the ray
        // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);







    }

    public void MoveCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit);
        if (isHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
}
