using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicFirstWeapon : TriggerDamage, IWeapon //deve ter o gatilho de causar dano e é uma arma
{
    [SerializeField]
    private float atackTime = 0.2f;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void Atack() // quando esta função for chamada o objeto se ativa e desativa apos um tempo
    {
        gameObject.SetActive(true); // habilida o objeto

        StartCoroutine(PerformAtack()); // após um tempo desabilita
    }

    private IEnumerator PerformAtack() // essa funcão consegue eperar um tempo antes de outras ações
    {
        //TODO: quamdo configurar animações configurar tambem o isAtacking
        yield return new WaitForSeconds(atackTime);
        gameObject.SetActive(false);
    }
}
