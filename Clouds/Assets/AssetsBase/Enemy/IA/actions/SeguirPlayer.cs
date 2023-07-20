using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[Action("Clouds/SeguirPlayer")]
public class SeguirPlayer : BasePrimitiveAction 
{
    /*[InParam("Player")]
    private GameObject Player;*/

    [InParam("Entidade")]
    public GameObject Entidade;

    [InParam("Velocidade")]
    public float velocidade = 5;


    public string playerTag = "Player"; // tornar privada após testes
    private UnityEngine.Transform playerTransform;
    private UnityEngine.Transform entidadeTransform;

    public override void OnStart()
    {
        base.OnStart();
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag); //pega as informações do objeto player contidos no player que tiver a tag player
        playerTransform = playerObject.transform; // pega as informações da posição do player e enviar para a variavel playertransform
        entidadeTransform = Entidade.transform;
    }
    public override TaskStatus OnUpdate()
    {
        if( playerTag == null)
        {
            return TaskStatus.ABORTED; 
        }
        entidadeTransform.position = Vector2.MoveTowards(entidadeTransform.position, playerTransform.position, velocidade * Time.deltaTime);
        Debug.Log("Seguindo");

        return TaskStatus.RUNNING;
    }
}
