using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform originalTarget;
        private Transform m_target;// target to aim for
        public bool attacking;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            originalTarget = FindObjectOfType<Player>().transform;

            agent.updateRotation = false;
            agent.updatePosition = true;
        }



        private void Update()
        {
            if (m_target != null)
                agent.SetDestination(m_target.position);

            if (attacking)
            {
                this.m_target = this.transform;
            } else
            {
                this.m_target = originalTarget;
            }

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);               
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }


        public void SetTarget(Transform target)
        {
            this.m_target = target;
        }

        public void SetAttackingTrue()
        {
            attacking = true;
        }
        public void SetAttackingFalse()
        {
            attacking = false;
        }
    }
}
