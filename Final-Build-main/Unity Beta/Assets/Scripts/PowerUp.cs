using UnityEngine;

public class SpeedUpPowerUp : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float powerUpDuration = 10f;

    private float originalSpeed;
    private bool isPowerUpActive = false;

    private void Start()
    {
        // Store the original speed of the object
        originalSpeed = GetComponent<PlayerMove>().baseSpeed;
    }

    private void Update()
    {
        if (isPowerUpActive)
        {
            powerUpDuration -= Time.deltaTime;

            if (powerUpDuration <= 0f)
            {
                // Power-up duration has expired, reset speed
                ResetSpeed();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the "PowerUp" tag
        if (other.CompareTag("PowerUp"))
        {
            ActivatePowerUp(originalSpeed); // Pass the original speed to the power-up
            Destroy(other.gameObject);
        }
    }

    public void ActivatePowerUp(float currentSpeed)
    {
        Debug.Log("Power-up activated!");

        // Increase the speed
        GetComponent<PlayerMove>().CurrentSpeed = currentSpeed * speedMultiplier;
        isPowerUpActive = true;

        // You can add visual/audio effects here if needed
    }

    private void ResetSpeed()
    {
        // Reset the speed to the original speed
        GetComponent<PlayerMove>().CurrentSpeed = originalSpeed;
        isPowerUpActive = false;
        Debug.Log("Power-up deactivated!");
    }
}
