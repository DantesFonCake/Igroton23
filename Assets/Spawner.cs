using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Spawn()
    {
        var random = Random.Range(-8, 8);
        GameObject nextEnemy = Instantiate(Enemy, new Vector2(random, transform.position.y), Quaternion.identity);
        //Destroy(nextEnemy);
    }
}