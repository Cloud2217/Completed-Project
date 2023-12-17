using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public GameObject swordHBPrefab;
    private GameObject swordHB;
    private Rigidbody playerRB;
    private bool isAlive = true;
    Animator animator;

    public float baseSpeed = 6.0f;
    private float currentSpeed;
    public float rotationSpeed;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Initialize speed
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if (isAlive)
        {
            if (!animator.GetBool("isAttacking"))
            {
                Walk();
            }
        }
        else
        {
            if (Input.GetKey("space"))
            {
                SceneManager.LoadScene("Level 1");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            gameOverText.gameObject.SetActive(true);
            isAlive = false;
            animator.SetBool("gameOver", true);
        }
        else if (other.CompareTag("PowerUp"))
        {
            SpeedUpPowerUp powerUpScript = other.GetComponent<SpeedUpPowerUp>();

            if (powerUpScript != null)
            {
                powerUpScript.ActivatePowerUp(currentSpeed);
                Destroy(other.gameObject);
            }
        }
    }

    private void DestroyHitbox()
    {
        Destroy(swordHB);
    }

    void Walk()
    {
        if (Input.GetKey("space") && swordHB == null)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);

            swordHB = Instantiate(swordHBPrefab, transform.position + transform.forward * 2f, transform.rotation);

            Invoke("DestroyHitbox", 0.5f);
            return;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        direction.Normalize();

        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public float CurrentSpeed
    {
        get { return currentSpeed; }
        set { currentSpeed = value; }
    }
}
