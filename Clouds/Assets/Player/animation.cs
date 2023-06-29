using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator anim;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 moviment = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", moviment.x);
        anim.SetFloat("Vertical", moviment.y);
        anim.SetFloat("Velocidade", moviment.magnitude);

        transform.position = transform.position + moviment * speed * Time.deltaTime; 
        
    }
}
