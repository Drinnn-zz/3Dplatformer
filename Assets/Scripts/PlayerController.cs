using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody rb;
    private AudioSource coinPickupAudio;

    private void Awake(){
        rb = GetComponent<Rigidbody>();
        coinPickupAudio = GetComponent<AudioSource>();

        Time.timeScale = 1.0f;
    }

    private void Update(){
        if (GameManager.instance.isPaused)
            return;
        Move();
        Jump();
    }

    private void Move(){
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(xInput, 0, zInput) * moveSpeed;
        direction.y = rb.velocity.y;
        rb.velocity = direction;

        Vector3 facingDirection = new Vector3(xInput, 0, zInput);
        if(facingDirection.magnitude > 0)
            transform.forward = facingDirection;
    }

    private void Jump(){
        if (Input.GetButtonDown("Jump")){
            Ray ray1 = new Ray(transform.position + new Vector3(0.5f, 0, 0.5f), Vector3.down);
            Ray ray2 = new Ray(transform.position + new Vector3(-0.5f, 0, 0.5f), Vector3.down);
            Ray ray3 = new Ray(transform.position + new Vector3(0.5f, 0, -0.5f), Vector3.down);
            Ray ray4 = new Ray(transform.position + new Vector3(-0.5f, 0, -0.5f), Vector3.down);

            bool cast1 = Physics.Raycast(ray1, 0.7f);
            bool cast2 = Physics.Raycast(ray2, 0.7f);
            bool cast3 = Physics.Raycast(ray3, 0.7f);
            bool cast4 = Physics.Raycast(ray4, 0.7f);
            
            if (cast1 || cast2 || cast3 || cast4){
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")){
            GameManager.instance.OnGameOver();
        } else if (other.CompareTag("Coin")){
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);
            coinPickupAudio.Play();
        } else if (other.CompareTag("EndGoal")){
            GameManager.instance.OnLevelEnd();
        }
    }
}