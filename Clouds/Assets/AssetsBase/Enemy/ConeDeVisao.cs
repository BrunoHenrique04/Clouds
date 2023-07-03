using UnityEngine;

public class ConeDeVisao : MonoBehaviour
{
    public float raio = 5f;
    public float angulo = 60f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector2 direcaoInicial = Quaternion.Euler(0, 0, -angulo / 2) * transform.up;
        Vector2 direcaoFinal = Quaternion.Euler(0, 0, angulo / 2) * transform.up;

        Gizmos.DrawWireSphere(transform.position, raio);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direcaoInicial * raio);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direcaoFinal * raio);

        float step = 0.1f;
        float t = 0;

        while (t <= 1)
        {
            Vector2 lerpedDirection = Vector2.Lerp(direcaoInicial, direcaoFinal, t);
            Gizmos.DrawRay(transform.position, lerpedDirection * raio);
            t += step;
        }
    }
}
