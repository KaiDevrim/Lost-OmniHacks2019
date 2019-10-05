using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject _Key;

    public GameObject door;

    //public float speed = 2f;
    public int key;

    public int keysNeeded = 1;
    public float timer = 0;

    public GameObject nextScene;
    public Collider2D objectCollider;
    public GameObject ObstaclesFine;
    private Transform playerTransform;

    [SerializeField] public float playerX;

    [SerializeField] public float playerY;

    private Rigidbody2D rb;
    public float vx;
    public float vy;
    public float x;

    public float y;

    public GameObject keyObject;

    public float keyX;

    public float keyY;

    public GameObject doorObject;
    //private BoxCollider2D collider;

    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        //collider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var Sideways = Input.GetAxis("Horizontal");
        var UpDown = Input.GetAxis("Vertical");
        Movement();
        playerY = transform.position.y;
        playerX = transform.position.x;
        
        keyX = keyObject.transform.position.x;
        keyY = keyObject.transform.position.y;
        BroadcastMsg();
        
        if(this.transform.position.y == -32f){
            BroadcastMsg();
        }
        
        /*if (Math.Sqrt(Math.Pow(playerX - keyX, 2) + Math.Pow(playerY - keyY, 2)) <= 100) //calibrate 100
        {
            float keyPosition;
            //transform keyX by (keyX-playerX)*0.1
            
            keyObject.transform.position = new Vector3(keyX-playerX) *0.1f);
            transform.position.y = keyObject.transform.position.y + new Vector3((keyY-playerY)* 0.1f,0,0);
            
            //transform keyY by (keyY-playerXy*0.1
            
        }*/
        //Debug.Log(playerX);
        //Debug.Log(playerY);
        //RotateChar();
    }
    void BroadcastMsg(){
        BroadcastMessage("Endings", 1);
    }
    private void Movement()
    {
        timer += 0.0000001f;
        vx *= 0.95f - timer;
        vy *= 0.95f - timer;
        playerTransform.transform.Translate(vx * Time.deltaTime * Vector3.right);
        playerTransform.transform.Translate(vy * Time.deltaTime * Vector3.up);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) vx -= 0.5f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) vx += 0.5f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) vy += 0.5f;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) vy -= 0.5f;
    
        
        //x += vx;
        //y += vy;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boid"))
        {
            Destroy(this);
            Debug.Log("Touch me!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.gameObject.CompareTag("Key"))
        {
            //Destroy(other);
            key = 1;
            Debug.Log("Key Got!");

            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Door"))
        {
            if (key == keysNeeded)
            {
                Destroy(this);
                Debug.Log("Did Door");

                //SceneManager.LoadScene($"Level{levelCounter}");
                if (SceneManager.GetActiveScene().name == "Level1") SceneManager.LoadScene("Level2");
                if (SceneManager.GetActiveScene().name == "Level2") SceneManager.LoadScene("Level3");
                if (SceneManager.GetActiveScene().name == "Level3") SceneManager.LoadScene("Level4");
                if (SceneManager.GetActiveScene().name == "Level4") SceneManager.LoadScene("Level5");
                if (SceneManager.GetActiveScene().name == "Level5") SceneManager.LoadScene("End");
            }
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this);
            Debug.Log("Touch me!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    
}