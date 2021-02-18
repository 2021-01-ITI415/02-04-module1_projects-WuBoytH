using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject player;
    public Text countText;

    [Header("Set Dynamically")]
    private Rigidbody playerRigidbody;
    private int count;
    public float xVelocity;
    public float maxXVelocity;
    public float maxGravity;
    public float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        xVelocity = 0f;
        maxGravity = -67.82f;
        maxXVelocity = 3.7f;
        jumpVelocity = 17.36f;
        count = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Vector3 randomPos = new Vector3(Random.Range(-14.0f, 14.0f), Random.Range(-3.3f, -4.5f), 0f);
            other.gameObject.transform.position = randomPos;
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text= "Coins: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = playerRigidbody.velocity;
        if (velocity.x >= 8.7f || velocity.x <= -8.7f){
            jumpVelocity = 20.36f;
        }
        else{
            jumpVelocity = 17.36f;
        }
        if (Input.GetKeyDown(KeyCode.X)){
            maxXVelocity = 9.1f;
        }
        if (Input.GetKeyUp(KeyCode.X)){
            maxXVelocity = 3.7f;
        }
        if (Input.GetKeyDown(KeyCode.Z)){
            if(velocity.y == 0f){
                maxGravity = -34.79f;
                velocity.y = jumpVelocity;
                Physics.gravity = new Vector3(0f, maxGravity, 0f);
                playerRigidbody.velocity = velocity;
            }
        }
        if (Input.GetKeyUp(KeyCode.Z)){
            maxGravity = -67.82f;
            Physics.gravity = new Vector3(0f, -67.82f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            if(velocity.x < maxXVelocity){
                velocity.x += 0.9f;
                if(velocity.x >= maxXVelocity){
                    velocity.x = maxXVelocity;
                }
            }
            playerRigidbody.velocity = velocity;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            if(velocity.x > -maxXVelocity){
                velocity.x -= 0.9f;
                if(velocity.x <= -maxXVelocity){
                    velocity.x = -maxXVelocity;
                }
            }
            playerRigidbody.velocity = velocity;
        }
    }
}
