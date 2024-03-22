using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Referência para o transform do jogador
    public float speed = 10000f; // Velocidade de movimento do inimigo (aumentada)
    private Rigidbody rb; // Referência para o componente Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtém o componente Rigidbody
    }

    void FixedUpdate()
    {
        // Verifica se o jogador está disponível
        if (player != null)
        {
            // Calcula a direção para o jogador
            Vector3 direction = (player.position - transform.position).normalized;

            // Aplica uma força na direção do jogador, multiplicando pela velocidade (aumentada)
            rb.AddForce(direction * speed, ForceMode.Force);
        }
    }
}
