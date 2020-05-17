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
            InteractWithMovement();
            InteractWithCombat();

        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (var hit in hits)
            {
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();
                if(combatTarget!=null)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        GetComponent<fighter>().Attack(combatTarget);

                    }
                    
                }

            }

        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveCursor();
            }
        }

        public void MoveCursor()
        {
            RaycastHit hit;
            bool isHit = Physics.Raycast(GetMouseRay(), out hit);
            if (isHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }


}
