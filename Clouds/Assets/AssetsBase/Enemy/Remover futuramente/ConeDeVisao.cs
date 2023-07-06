using UnityEngine;

public class ConeDeVisao : MonoBehaviour
{
    public float raio = 5f;
    public float angulo = 60f;

    private void OnDrawGizmos() // - Este é um método especial do Unity que é chamado durante o desenho do Gizmo no Editor.
    {
        Gizmos.color = Color.yellow; //- Define a cor do Gizmo como amarelo.

        Vector2 direcaoInicial = Quaternion.Euler(0, 0, -angulo / 2) * transform.up; // Calcula a direção inicial do cone de visão. Usando um Quaternion, rotaciona o vetor transform.up (vetor para cima do objeto) por metade do ângulo em torno do eixo Z.
        Vector2 direcaoFinal = Quaternion.Euler(0, 0, angulo / 2) * transform.up;

        Gizmos.DrawWireSphere(transform.position, raio); // Desenha uma esfera de arame (wireframe) para representar a área de alcance do cone de visão.
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direcaoInicial * raio);// Desenha uma linha que vai do centro do objeto até o limite inicial do cone de visão.
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direcaoFinal * raio); //Desenha uma linha que vai do centro do objeto até o limite final do cone de visão.

        float step = 0.1f; // - Define o incremento para interpolação linear entre as direções inicial e final.
        float t = 0; // Variável de controle para a interpolação linear.

        while (t <= 1) //- Inicia um loop para realizar a interpolação linear entre as direções inicial e final.
        {
            Vector2 lerpedDirection = Vector2.Lerp(direcaoInicial, direcaoFinal, t); //Realiza uma interpolação linear entre as direções inicial e final, com base no valor atual de t.
            Gizmos.DrawRay(transform.position, lerpedDirection * raio); // Desenha um raio a partir do centro do objeto na direção interpolada, multiplicado pelo raio do cone de visão.
            t += step; // - Incrementa o valor de t para a próxima iteração da interpolação linear.
        }
    }
}
