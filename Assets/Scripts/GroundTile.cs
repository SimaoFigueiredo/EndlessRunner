using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.gameObject.name == "Player")
        {
            groundSpawner.SpawnTile();
            
            // Destruímos o chão depois de 2 segundos para dar tempo de ele passar
            Destroy(gameObject, 2f);
        }
    }
}