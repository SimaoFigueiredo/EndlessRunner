using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O jogador que a câmara vai seguir
    private Vector3 offset;  // A distância inicial entre a câmara e o jogador

    void Start()
    {
        // Calcula a distância exata entre a câmara e o jogador no momento em que o jogo começa
        offset = transform.position - target.position;
    }

    // Usamos o LateUpdate para a câmara (corre logo a seguir ao Update do jogador)

    void LateUpdate()
    {
        // Move a câmara para a posição do jogador + a distância inicial
        Vector3 newPosition = target.position + offset;
        //newPosition.x = 0;
        transform.position = newPosition;
    }
}