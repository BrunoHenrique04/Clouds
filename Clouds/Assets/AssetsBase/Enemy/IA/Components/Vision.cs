using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [Range(0.5f, 10.0f)]
    public float visionRange = 5;

    [Range(0, 360)]
    public float visionAngle = 30;

    public bool IsVisible(GameObject target)
    {
        if (target == null)
        {
            return false;
        }
        if (Vector2.Distance(transform.position, target.transform.position) > visionRange) // se estiver fora do alcance de visão retorna falso
        {
            return false;
        }
        Vector2 toTarget = target.transform.position - transform.position;
        Vector3 visionDirection = Vector3.right;
        if (Vector2.Angle(visionDirection, toTarget) > visionAngle /2 )
        {
            return false;
        }
        // TODO: checar objetos bloqueando a visão
        return true;
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange); //cria uma esphera em 2d (posição, tamanho)

        Vector3 visionDirection = Vector3.right;
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, visionAngle/2) * visionDirection * visionRange);//cria uma linha(origem,final) na origem final atribui a metado do angulo para cima
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -visionAngle / 2) * visionDirection * visionRange);//cria uma linha(origem,final) na origem final atribui a metado do angulo para baixo


    }

}
