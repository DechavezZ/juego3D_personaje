using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    public int numberOfPlatforms = 20;

    public float distanceBetween = 6f;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-3f, 3f),
                0,
                i * distanceBetween
            );

            Instantiate(platformPrefab, position, Quaternion.identity);
        }
    }
}