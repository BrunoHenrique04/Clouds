using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public Vector2 Velocidade = new Vector2(20, 20);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 moviment = new Vector3(Velocidade.x * inputX, Velocidade.y * inputY, 0);

        moviment *= Time.deltaTime;

        transform.Translate(moviment);
    }

}
