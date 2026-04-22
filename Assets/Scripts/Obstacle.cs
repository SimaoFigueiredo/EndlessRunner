using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float tempoDeVida = 120f; // Tempo que demora para o obstaculo ser destruido

    void Start()
    {
        // Assim que o obstáculo nasce, começa uma contagem decrescente para se destruir
        Destroy(gameObject, tempoDeVida);
    }
}