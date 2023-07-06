using BBUnity.Actions;
using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("Clouds/Detecção/IsTargetVisible")]

public class IsTargetVisivel : GOCondition
{

    [InParam("Player")]
    private GameObject Player;

    [InParam("Vision")]
    private Vision aIVision;

    [InParam("TargetMemoryDuration")]
    private float targetMemoryDuration;

    private float forgetTargetTime;
    public override bool Check()
    {
        if (aIVision.IsVisible(Player))
        {
            forgetTargetTime = Time.time + targetMemoryDuration;
            return true;

        }
        return Time.time < forgetTargetTime;
    }
}
