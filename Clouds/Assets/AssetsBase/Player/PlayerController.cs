using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(IDamageable))] //obriga que o player tenha o component IDamageable
public class PlayerController : MonoBehaviour
{
    IWeapon weapon; // cria uma variavel da interface IWeapon
    [SerializeField]
    GameObject weaponObject;

    IDamageable damageable; // crio uma variavel da interface IDamageable com o nome damageable

    public float speed;
    public Animator anim;

    private void Start() 
    {
        if (weaponObject != null)
        {
            weapon = weaponObject.GetComponent<IWeapon>(); // acesso o objeo da arma e pego a interface IWeapon que está nela e atribuo a variavel Weapon
        }
        // inicio = se inscrevendo no sistema de morte
        damageable = GetComponent<IDamageable>(); // atribuo a variavel as informações da interface
        damageable.DeathEvent += OnDeath; // 3° fase = quando esse evento for chamado execute a função OnDeath
        //fim = se desinscrevendo do sistema de forte
    }

    private void OnDestroy()
    {
        // inicio = se desinscrevendo no sistema de morte
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
        // fim = se desinscrevendo no sistema de morte

    }
    void Update()
    {

        Vector3 moviment = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f); // controle de input
        // Controle de animações
        anim.SetFloat("Horizontal", moviment.x);
        anim.SetFloat("Vertical", moviment.y);
        anim.SetFloat("Velocidade", moviment.magnitude);
        // Fim Controle Animações
        transform.position = transform.position + moviment * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Z) && weapon != null) //TODO: ALTERAR PARA CLICK DO MOUSE
        {
            weapon.Atack(); //acesso o IWeapon e executo o atack
        }
    }

    private void OnDeath() //Função que mata o objeto 
    {
         Debug.Log("TOMEI DANO");
          Destroy(gameObject);
    }
}
