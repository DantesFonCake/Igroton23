using UnityEngine;

public class HealthDownTimer : MonoBehaviour
{
    private const float MaxTimeInSeconds = 60;
    private float TargetTimeInSeconds = MaxTimeInSeconds;
    public Player Player;

    public void Update()
    {
        Debug.Log($"Current timer value = {TargetTimeInSeconds}");
        if (TargetTimeInSeconds <= 0)
        {
            TargetTimeInSeconds = MaxTimeInSeconds;

            return;
        }

        var delta = Time.deltaTime;
        Player.TakeDamage(delta);
        TargetTimeInSeconds -= delta;
    }
}