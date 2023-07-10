using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    private string Player = "Player";
    private GameObject playerObject;
    private Color cor = Color.red;

    [Range(0.5f, 10.0f)]
    public float visionRange = 5;

    [Range(0, 360)]
    public float visionAngle = 30;

    private Vector3 visionDirection;

    public void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(Player);
    }

    public bool IsVisible(GameObject target)
    {
        if (target == null)
        {
            return false;
        }
        if (Vector3.Distance(transform.position, target.transform.position) > visionRange)
        {
            return false;
        }
        Vector3 toTarget = target.transform.position - transform.position;
        if (Vector3.Angle(visionDirection, toTarget) > visionAngle / 2)
        {
            return false;
        }
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = cor;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        visionDirection = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector3.up; // Aplica a rotação do objeto ao vetor (0, 1, 0)

        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, visionAngle / 2) * visionDirection * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -visionAngle / 2) * visionDirection * visionRange);
    }

    private void Update()
    {
        if (IsVisible(playerObject))
        {
            cor = Color.green;
        }
        else
        {
            cor = Color.yellow;
        }
    }
}