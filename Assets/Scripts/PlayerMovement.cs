using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    
    public float laneDistance = 3f; // A distância entre cada faixa
    private int desiredLane = 1; // Começamos no meio (0 = Esquerda, 1 = Meio, 2 = Direita)

    public float jumpForce = 7f;

    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
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

        // 2. Calcular o movimento para a frente (como já tínhamos)
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

        // 3. Juntar a posição lateral suave com o movimento para a frente
        Vector3 newPosition = new Vector3(
            Mathf.Lerp(rb.position.x, targetX, 10f * Time.fixedDeltaTime),
            rb.position.y,
            rb.position.z + forwardMove.z
        );

        // 4. Mover o boneco de vez!
        rb.MovePosition(newPosition);
    }

    void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            // Dá um "pontapé" na física do boneco para cima
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}