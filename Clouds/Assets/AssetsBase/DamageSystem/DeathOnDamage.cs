using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Implementação especifica do da interface IDamageable
public class DeathOnDamage : MonoBehaviour, IDamageable // tudo que tiver este script pode receber dano
{
    public bool IsDead { get; private set; } // outros componentes poderão acessar a variavel mas só é possivel alterar o valor por scripts

    //o que ira toamr dano ira se inscrever no evento DeathEvent
    public event Action DeathEvent;
    private void Awake()
    {
        IsDead = false;
    }

    public void TakeDamage(int damage)  
    {
        IsDead = true;
        DeathEvent.Invoke(); //a função executa o evento de morte avisando todos que estão incritos no evento de que ele foi executado
    }
}

// 2.1° quando o TakeDamage for executado aviso para todos que estão incritos nele que o DeathEvent foi chamado
