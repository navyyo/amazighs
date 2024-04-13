using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform tomatoPrefab;
    [SerializeField] private Vector3 spawnPosition; // Define the spawn position
    public void Connect()
    {
        Debug.Log("connect!");
        Transform tomatoTransform = Instantiate(tomatoPrefab, spawnPosition, Quaternion.identity);
    }
}

