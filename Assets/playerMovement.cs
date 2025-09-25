using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private int playerHealth = 100;

    [SerializeField]
    private Vector2 moveInput;
    private InputSystem_Actions inputActions;
    float moveSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Move.performed += context => moveInput = context.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += context => moveInput = Vector2.zero;
        inputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime * moveSpeed;
        transform.Translate(movement);

        if(playerHealth <= 0)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NextLevel"))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (currentScene < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(currentScene + 1);
            }
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerHealth -= 20;
        }
    }
}