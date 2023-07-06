using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public string playerTag = "Player"; // armazena a tag player
    public float velocidade = 5f; // velocidade
    public Transform playerTransform; //cria uma variavel para armazenar a posição do player em vector 2
    private ConeDeVisao coneDeVisao; //variavel para armazenar as informações do cone

    private void Awake()
    {
        coneDeVisao = GetComponentInChildren<ConeDeVisao>(); // pega as informações do codigo do cone no objeto filho
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag); //pega as informações do objeto player contidos no player que tiver a tag player
        playerTransform = playerObject.transform; // pega as informações da posição do player e enviar para a variavel playertransform
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, coneDeVisao.raio);// recebe dois parâmetros: o primeiro é a posição do centro do círculo de verificação de colisão, que é obtida através de transform.position (a posição do objeto que possui esse script). O segundo parâmetro é o raio do círculo de verificação, que é obtido de coneDeVisao.raio (uma variável definida no script ConeDeVisao).
        Vector2 direcao = playerTransform.position - transform.position; //pega a diferença entre playe e o inimigo
        


        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(playerTag) && (direcao.y >= 1.30 || direcao.x >= 1.30 || direcao.x <= -1.30 || direcao.y <= -1.30))// verifica se o player esta dentro do circulo e se esta ou não encostando no player
            {
               Debug.Log("Player Detectado");
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, velocidade * Time.deltaTime); // anda em direção ao player
            } else if (collider.CompareTag(playerTag))
            {
               Debug.Log("ATACANDO"); // se estiver encostando no player e dentro da area do collider, ia atacar
            }
        }
    }
}

 



