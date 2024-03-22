using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    //Counter for the number of pickups collected.
    private int count;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 0;

    // Reference to the TextMeshProUGUI component.
    public TextMeshProUGUI countText;

    // Reference to the GameObject that displays the win text.
    public GameObject winTextObject;

    // Reference to the GameObject that displays the lose text.
    public GameObject loseTextObject;

    // Reference to the TimeManager component.
    public TimeManager timeManager;

    // Boolean to check if the player can collect pickups.
    private bool canCollectPickups = true;

    // Load the Menu scene.
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }


    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        // Set the count to zero.
        count = 0;

        // Set the countText to display the count.
        SetCountText();
        // Set the winText to display the win message.
        winTextObject.SetActive(false);

        // Set the loseText to display the lose message.
        loseTextObject.SetActive(false);
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        // Update the text value of the countText.
        countText.text = "Count: " + count.ToString();
        // Check if the player has collected all the pickups.
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            Invoke("LoadMenuScene", 2f); // Carrega a cena do menu após 3 segundos
        }
    }
    void Update()
    {
        // Check if the time is up
        if (timeManager.IsTimeUp()) // If time is up
        {
            canCollectPickups = false;
            if (count < 12){
                loseTextObject.SetActive(true);
            }
            Invoke("LoadMenuScene", 2f); // Carrega a cena do menu após 3 segundos
        }
    }
    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    // ! In Unity codes, the function name is case-sensitive. 
    // ! It means that the function name FixedUpdate is different from fixedupdate.
    // ! In general, in unity  we dont use camel case for function names, but we use it for variables.
    // ! Functions are named using PascalCase. 
    {
        // Check if the time is up
        if (!timeManager.IsTimeUp()) // If time is not up
        {
            // Create a 3D movement vector using the X and Y inputs.
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);

            // Apply force to the Rigidbody to move the player.
            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the time is up
        if (canCollectPickups)
        {
            // Check if the player has collided with a pickup.
            if (other.gameObject.CompareTag("PickUp"))
            {
                GameObject coin = GameObject.Find("Coin");
                coin.GetComponent<AudioSource>().Play();
                other.gameObject.SetActive(false);
                count = count + 1;

                SetCountText();
            }
        }
    }
}