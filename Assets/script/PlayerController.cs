using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
    private bool isOnTheGround = true;
    public bool gameOver;
    // Start is called before the first frame update
    
    
    void Start()
    {
        gameOver = false;
        playerRigidbody = GetComponent<Rigidbody>();
       
        Physics.gravity *= gravityModifier;
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Salto
        //Presionar tecla para saltar
            if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnTheGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            }
        
       
       
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        //Utilizando los tags
        if (otherCollider.gameObject.CompareTag("ground"))
        {
            isOnTheGround = true;
        }

        if (otherCollider.gameObject.CompareTag("obstaculo"))
        {
            // Ded
            gameOver = true;
            int randomDeath = Random.Range(1, 3);
            playerAnimator.SetTrigger ("Death_b");
            playerAnimator.SetInteger("DeathType.int", randomDeath);

        }
        
    }
}
