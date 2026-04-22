using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configurações de Velocidade")]
    public float speed = 10f;             // Velocidade inicial
    public float aceleracao = 0.2f;      // Quanto a velocidade aumenta por segundo
    public float velocidadeMaxima = 65f; // O limite para não ficar impossível

    [Header("Movimento e Saltos")]
    public Rigidbody rb;
    public float laneDistance = 3f; // A distância entre cada faixa
    private int desiredLane = 1;    // Começamos no meio (0 = Esquerda, 1 = Meio, 2 = Direita)
    public float jumpForce = 11f;
    public float gravidadeExtra = 20f;
    private bool estaMorto = false;

    void Update()
    {
        if (speed < velocidadeMaxima)
        {
            // Aumenta a velocidade aos poucos a cada frame
            speed += aceleracao * Time.deltaTime;
        }


        // Se carregar na seta Direita ou no 'D'
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++; // Aumenta o número da faixa
            if (desiredLane == 3) // Se tentar ir além da faixa da direita
                desiredLane = 2;  // obriga-o a ficar na direita.
        }

        // Se carregar na seta Esquerda ou no 'A'
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--; // Diminui o número da faixa
            if (desiredLane == -1) // Se tentar ir além da faixa da esquerda
                desiredLane = 0;   // obriga-o a ficar na esquerda.
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // 1. Descobrir qual é a posição X correta com base na faixa atual
        float targetX = 0f;
        if (desiredLane == 0)
            targetX = -laneDistance;
        else if (desiredLane == 1)
            targetX = 0f;
        else if (desiredLane == 2)
            targetX = laneDistance;

        // 2. Calcular o movimento para a frente (Usa a nossa 'speed' que agora está a crescer)
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

        // 3. Juntar a posição lateral suave com o movimento para a frente
        Vector3 newPosition = new Vector3(
            Mathf.Lerp(rb.position.x, targetX, 10f * Time.fixedDeltaTime),
            rb.position.y,
            rb.position.z + forwardMove.z
        );

        // 4. Mover o boneco de vez
        rb.MovePosition(newPosition);

        // 5. Puxa o boneco para baixo para o salto ser rápido e não flutuar 
        rb.AddForce(Vector3.down * gravidadeExtra, ForceMode.Acceleration);
    }

    void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    //SISTEMA DE COLISÃO
    private void OnCollisionEnter(Collision collision)
    {
        // Se já estivermos mortos, o código para aqui e ignora os ricochetes!
        if (estaMorto) return; 

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Morrer();
        }
    }

    void Morrer()
{
    if (estaMorto) return;
    estaMorto = true;

    // 1. Parar o movimento
    speed = 0f;
    aceleracao = 0f;
    enabled = false; 
    rb.linearVelocity = Vector3.zero; 
    rb.AddForce(Vector3.down * 50f, ForceMode.Impulse);

    // 2. RECOLHER OS DADOS REAIS
    // Calculamos a distância percorrida (Z) e arredondamos para um número inteiro
    int finalDistance = Mathf.FloorToInt(transform.position.z);

    // Vamos buscar o ScoreManager que está na cena para saber as moedas
    int finalCoins = 0;
    ScoreManager sm = FindObjectOfType<ScoreManager>();
    if (sm != null) {
        finalCoins = sm.totalMoedas;
    }

    // 3. ENVIAR PARA O MENU
    FindObjectOfType<MenuManager>().ShowGameOver(finalDistance, finalCoins);

    Debug.Log("GAME OVER! Distância: " + finalDistance + " Moedas: " + finalCoins);
}
}