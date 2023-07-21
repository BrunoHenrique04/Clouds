using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class EnemyGeneralFunctions : MonoBehaviour
{
    IDamageable damageable;

    [SerializeField]
    private TriggerDamage damager; // defino no inspetor aonde esta o TriggerDamage do inimigo

    // Start is called before the first frame update
    void Start()
    {
        // se inscreve no evento de morte
        damageable = GetComponent<IDamageable>(); // gravo na variavel o component IDamageable
        damageable.DeathEvent += OnDeath;  // quando o evento de morte do IDamageable do objeto for chamado a funcão ondeath sera executada
        // se inscreve no evento de morte
    }

    private void OnDestroy() // quando o objeto for destruido executar essa função
    {
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDeath;  // se desinscreve do evento quanodo o objeto for destruido
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDeath()
    {
        enabled = false;
        damager.gameObject.SetActive(false); //Destaivo o TriggerDamage
        //TODO: definir um tempo antes do inimigo sumir
        Destroy(gameObject);
    }
}
