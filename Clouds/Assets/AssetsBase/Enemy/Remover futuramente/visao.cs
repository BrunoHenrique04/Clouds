using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

[Action("Clouds/FollowVision")]
public class FollowVisions : MonoBehaviour
{
    public string playerTag = "Player";
    private Transform playerTransform;
    private Transform ObjetoPaiTransform;
    [Range(0f, 50f)]
    public float rotationSpeed = 3;

    public void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag(playerTag);
        if (Player == null) { Debug.LogError("O objeto " + playerTag + " não foi encontrado"); }
        if (transform.position == null) { Debug.LogError("O objeto principal ñão foi localizado"); }
        playerTransform = Player.transform;
        ObjetoPaiTransform = transform.parent;

    }

    public void Update()
    {
        //Debug.Log(playerTransform);
        //Debug.Log(transform);

        Vector3 direction = playerTransform.position - ObjetoPaiTransform.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //Debug.Log(transform.rotation);

    }
}
