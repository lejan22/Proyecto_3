using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private AudioSource cameraAudioSource;
    private AudioSource playerAudioSource;
    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
    private bool isOnTheGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticleSystem;
    public ParticleSystem dirtParticleSystem;
    public AudioClip jumpClip;
    public AudioClip crashClip;
    private int lives = 3;
    // Start is called before the first frame update


    void Start()
    {
        gameOver = false;
        playerRigidbody = GetComponent<Rigidbody>();
       
        Physics.gravity *= gravityModifier;
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        lives = 3;
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
            //Parar particulas de tierra
            dirtParticleSystem.Stop();
            //SFX salto
            playerAudioSource.PlayOneShot(jumpClip,1);
        }
        
       
       
    }
    private void OnCollisionEnter(Collision otherCollider)

    {
        //Si game over vale true, estoy ded, si vale false, estoy vivo.
        //Si !gameOver vale true, estoy vivo, si vale false, estoy ded.
        if (!gameOver)
        {
            //Utilizando los tags
            if (otherCollider.gameObject.CompareTag("ground"))
            {
                isOnTheGround = true;
                //Reiniciar al tocar el suelo las particulas
                dirtParticleSystem.Play(); 
            }

            if (otherCollider.gameObject.CompareTag("obstaculo"))
            {
                Destroy(otherCollider.gameObject);
                lives--;
                if (lives<= 0)
                {
                    GameOver();
                }

                
            }
        }
    }
    private void GameOver()
    {
        // Ded
        gameOver = true;
        int randomDeath = Random.Range(1, 3);
        playerAnimator.SetTrigger("Death_b");
        playerAnimator.SetInteger("DeathType.int", randomDeath);

        //Particulas
        Vector3 offset = new Vector3(0, 1.5f, 0);
        Instantiate(explosionParticleSystem, transform.position + offset, explosionParticleSystem.transform.rotation);
        //ParticleSystem explosionEscena = Instantiate(explosionParticleSystem, transform.position + new Vector3(0, 1.5f, 0), explosionParticleSystem.transform.rotation);
        //explosionParticleSystem.Play();
        //explosionEscena.Play();

        // Reproducir SFX de la explosón
        playerAudioSource.PlayOneShot(crashClip, 1);

        //bajar volumen de la musica de fondo
        cameraAudioSource.volume = 0.01f;
    }
}
