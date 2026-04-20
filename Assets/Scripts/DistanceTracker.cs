using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI distanceText;
    
    private float startingZ;

    void Start()
    {
        startingZ = player.position.z;
    }

    void Update()
    {
        // Calculamos a distância: posição atual menos a inicial
        float distanceTravelled = player.position.z - startingZ;

        distanceText.text = Mathf.FloorToInt(distanceTravelled).ToString() + "m";
    }
}