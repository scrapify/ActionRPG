using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;

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
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
            print("End of world");


        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (var hit in hits)
            {
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();
                if(combatTarget==null) continue;
                
                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<fighter>().Attack(combatTarget);

                }
                    
                 return true;

            }

            return false;

        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool isHit = Physics.Raycast(GetMouseRay(), out hit);
            if (isHit)
            {
                if(Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
               
                return true; 
            }
                return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }


}
