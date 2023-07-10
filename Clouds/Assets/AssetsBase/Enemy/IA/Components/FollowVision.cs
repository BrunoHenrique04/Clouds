using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[Action("Clouds/FollowVision")]
public class FollowVision : BasePrimitiveAction
{
    [InParam("Entidade")]
    public GameObject Entidade;

    [InParam("ControladorDeVisao")]
    public GameObject VisionControll;

    [InParam("Velocidade")]
    public float rotationSpeed = 5;

    public string playerTag = "Player";
    private UnityEngine.Transform playerTransform;
    private UnityEngine.Transform ObjetoPaiTransform;
    private UnityEngine.Transform VisionControllTR;


    public override void OnStart()
    {
        base.OnStart();

        GameObject Player =GameObject.FindGameObjectWithTag(playerTag);  
        playerTransform = Player.transform;
        ObjetoPaiTransform = Entidade.transform;
        VisionControllTR = VisionControll.transform;
        if (Player == null) { Debug.LogError("O objeto " + playerTag + " não foi encontrado"); }
        if (ObjetoPaiTransform.position == null) { Debug.LogError("O objeto principal ñão foi localizado"); }

    }

    public override TaskStatus OnUpdate()
    {
        //Debug.Log(playerTransform);
        //Debug.Log(transform);

        Debug.Log(ObjetoPaiTransform);
        Debug.Log(VisionControllTR);
        
             Vector3 direction = playerTransform.position - ObjetoPaiTransform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            VisionControllTR.rotation = Quaternion.Lerp(VisionControllTR.rotation, rotation, rotationSpeed * Time.deltaTime);
        //Debug.Log(transform.rotation);
        return TaskStatus.RUNNING;
    }
}
