using UnityEngine;

public class Star : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public Vector3 velocidadeRotacao = new Vector3(0f, 90f, 0f); // Rotação no eixo Y (padrão)
    public float amplitudeFlutuacao = 0.2f; 
    public float velocidadeFlutuacao = 1f; 

    Vector3 posicaoOriginal;

    void Start()
    {
        // Guarda a posição inicial para flutuar em torno dela
        posicaoOriginal = transform.position;
    }

    void Update()
    {
        // 1. ROTAÇÃO:
        // Multiplicamos pela velocidade e pelo tempo (Time.deltaTime) para ser suave
        transform.Rotate(velocidadeRotacao * Time.deltaTime);

        // 2. FLUTUAÇÃO:
        // Usamos a função Math.Sin para criar um movimento de onda suave
        float offset = Mathf.Sin(Time.time * velocidadeFlutuacao) * amplitudeFlutuacao;
        transform.position = posicaoOriginal + new Vector3(0f, offset, 0f);
    }
}