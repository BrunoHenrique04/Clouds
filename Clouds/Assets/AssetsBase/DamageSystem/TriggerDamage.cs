using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour 
{
    // deve ser atribuido ao objeto que ira causar o dano
    [Min(0)]
    [SerializeField] private int Damage = 10;
    private void OnTriggerEnter2D(Collider2D collision) // collision verifica tudo que colidiu com o objeto
    {
        IDamageable damageable = collision.GetComponent<IDamageable>(); // verifica se o que colidiu com o objeto contem a interface IDamageable
        if (damageable != null ) // caso contenha a interface, vou aceessar o objeto e o script que tenha essa interface (DeathOnDanage)
        {
            //Debug.Log(damageable.ToString());
            damageable.TakeDamage(Damage); // Executo a função TakeDamage contida no Interface do objeto 
        }
    }
}


// 1° fase = COLIDIR COM OBJETO -> ACESSAR IDAMAGEABLE DO OBJETO -> EXECUTO A FUNÇÃO TAKEDAMAGE
