using UnityEngine;

public class HealthDownTimer : MonoBehaviour
{
    private const float MaxTimeInSeconds = 60;
    private float TargetTimeInSeconds = MaxTimeInSeconds;
    private int currentIteration = 0;
    
    private Player player;
    private Spawner spawner;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawner = GetComponent<Spawner>();
    }

    public void Update()
    {
        //Debug.Log($"Current timer value = {TargetTimeInSeconds}");
        if (TargetTimeInSeconds <= 0)
        {
            currentIteration++;
            TargetTimeInSeconds = MaxTimeInSeconds;
            for(var i =0; i < currentIteration; i++ )
                spawner.Spawn();
            return;
        }

        var delta = Time.deltaTime * 5;
        player.TakeDamage(delta);
        TargetTimeInSeconds -= delta;
    }
}