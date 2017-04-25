using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID
{
	Idle = 0,
	Patrol = 1,
	Attack = 2,
	Smell = 3,
    Wander = 4,
    Follow = 5,
    Creep = 6
}

public class Demon : MonoBehaviour {

	/** we declareren de statemachine */
	private StateMachine stateMachine;

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    void FindVisibleTargets()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    print("Ik zie je.");
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

	// Use this for initialization
	void Start () {
		/** we halen een referentie op naar de state machine */
		stateMachine = GetComponent<StateMachine>();

		/** we voegen de verschillende states toe aan de state machine */
		MakeStates();
	}
	
	void MakeStates() {

	}

    void Update() //bool Peripheral()
    {
        FindVisibleTargets();
      //  return false;
    }
}
