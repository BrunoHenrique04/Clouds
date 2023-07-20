using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tudo que pode tomar dano acessara essa interface
public interface IDamageable 
{
    void TakeDamage(int damage); //chama a função o TakeDamage
    event Action DeathEvent; //action significa que isso é uma função void
    bool IsDead { get; } // tudo que pode tomar dano tera que ter o booleano avisando se esta morto ou não
}

// 2° fase = chama a função TakeDamage