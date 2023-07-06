using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Clouds/Patrol")]
public class Patrol : BasePrimitiveAction
{
    public override void OnStart()
    {
        base.OnStart();
       // Debug.Log("Patrulhando");
    }

    public override TaskStatus OnUpdate()
    {
        //Debug.Log("Patrulhando");
        return TaskStatus.RUNNING;
    }
}
