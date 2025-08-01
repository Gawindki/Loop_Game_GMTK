using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            player.transform.position = transform.position;
        }
        else
        {
            Debug.LogWarning("Kein GameObject mit dem Tag 'Player' gefunden!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
