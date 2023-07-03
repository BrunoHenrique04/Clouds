using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public string playerTag = "Player";
    public float velocidade = 5f;
    private Transform playerTransform;
    private ConeDeVisao coneDeVisao;

    private void Awake()
    {
        coneDeVisao = GetComponentInChildren<ConeDeVisao>();
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        playerTransform = playerObject.transform;
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, coneDeVisao.raio);
        Vector2 direcao = playerTransform.position - transform.position;
        


        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(playerTag) && (direcao.y >= 1.30 || direcao.x >= 1.30 || direcao.x <= -1.30 || direcao.y <= -1.30))
            {
                Debug.Log("Player Detectado");
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, velocidade * Time.deltaTime);
            } else if (collider.CompareTag(playerTag))
            {
                Debug.Log("ATACANDO");
            }
        }
    }
}

 



