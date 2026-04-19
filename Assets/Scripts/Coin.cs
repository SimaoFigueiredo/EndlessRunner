using UnityEngine;

public class Coin : MonoBehaviour
{
    public float velocidadeRotacao = 90f;
    private bool jaFoiApanhada = false; 

    void Update()
    {
        // Roda a moeda
        transform.Rotate(0, velocidadeRotacao * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Só faz alguma coisa se for o Player E se ainda não tiver sido apanhada
        if (!jaFoiApanhada && (other.CompareTag("Player") || other.gameObject.name == "Player"))
        {
            jaFoiApanhada = true;
            Debug.Log("Moeda Apanhada!"); // Vamos imprimir isto na consola só para ter a certeza
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // A moeda apaga-se sozinha ao fim de 120 segundos se não for apanhada
        Destroy(gameObject, 120f); 
    }
}