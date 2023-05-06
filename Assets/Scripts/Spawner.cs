using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    
    public void Spawn()
    {
        var random = Random.Range(-8, 8);
        var nextEnemy = Instantiate(enemy, new Vector2(random, transform.position.y), Quaternion.identity);
    }
}