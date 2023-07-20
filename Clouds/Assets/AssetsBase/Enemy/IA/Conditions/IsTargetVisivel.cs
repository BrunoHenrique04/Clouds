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
        bool isAvaliable = isAValiable();

        if (aIVision.IsVisible(Player) && isAValiable())
        {
            forgetTargetTime = Time.time + targetMemoryDuration;
            return true;

        }
        return Time.time < forgetTargetTime && isAvaliable;
    }

    private bool isAValiable()
    {
        if (Player == null)
        {
            return false;
        }
        //TODO: NÃO CHAMAR NO GETCOMPONENT NO UPDATE
        IDamageable damageable = Player.GetComponent<IDamageable>();//acesso o IDamageable do Player
        if (damageable != null)
        {
            return !damageable.IsDead; // só esta disponivel se nao esta morto
        }
        return false;
    }

}
