using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distanciaFaixa = 3.0f; // Distância entre as raias (esquerda/centro/direita)
    public float velocidadeFrente = 10.0f;
    private int faixaDesejada = 1; // 0: Esquerda, 1: Centro, 2: Direita

    void Update()
    {
        // 1. Movimento constante para a frente
        Vector3 posicaoAlvo = transform.position + transform.forward * velocidadeFrente * Time.deltaTime;

        // 2. Input para mudar de faixa (Setas ou A/D)
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (faixaDesejada < 2)
                faixaDesejada++;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (faixaDesejada > 0)
                faixaDesejada--;
        }

        // 3. Calcular a posição X baseada na faixa
        // Se faixaDesejada for 0, X = -3 | Se for 1, X = 0 | Se for 2, X = 3
        float alvoX = (faixaDesejada - 1) * distanciaFaixa;
        posicaoAlvo = new Vector3(alvoX, transform.position.y, posicaoAlvo.z);

        // 4. Suavizar o movimento lateral (Lerp)
        transform.position = Vector3.Lerp(transform.position, posicaoAlvo, 10 * Time.deltaTime);
    }
}