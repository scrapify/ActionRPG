using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
namespace RPG.Control{

    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveCursor();
            }

        }


        public void MoveCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isHit = Physics.Raycast(ray, out hit);
            if (isHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }
    }


}
