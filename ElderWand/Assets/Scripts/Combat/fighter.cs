using RPG.Movement;
using UnityEngine;

namespace RPG.Combat{
    public class fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        Transform target ;
               
        private void Update()
        {
            if(target==null) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }

            else
            {
                GetComponent<Mover>().Stop();
            }
                


        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void cancel()
        {
            target = null;
        }
    }
}

