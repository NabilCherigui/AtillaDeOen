using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{

    public override void Act()
    {
        transform.gameObject.tag = "Attack";
    }

    public override void Reason()
    {
        if (!Demon.Peripheral())
        {
            GetComponent<StateMachine>().SetState(StateID.Wander);
        }
        else
        {
            GetComponent<StateMachine>().SetState(StateID.Follow);
        }
    }
}
