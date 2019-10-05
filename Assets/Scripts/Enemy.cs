using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float coopersVar;
    public GameObject player;

    private Player playerScript;

    // Start is called before the first frame update
    private Transform playerTransform;

    [SerializeField] public float playerX;

    [SerializeField] public float playerY;

    private Rigidbody2D rb;
    public float vx;
    public float vy;

    [SerializeField] public float x; //GET MY X POSITION

    [SerializeField] public float y; //GET MY Y POSITION

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        x = transform.position.x;
        y = transform.position.y;
        Movement();
        if (player.transform.position.x == -11 || player.transform.position.x == 11)
        {
        }

        //Debug.Log($"The other player's x {playerScript.transform.position.x}");
        //Debug.Log($"The other player's y {playerScript.transform.position.y}");
        //Debug.Log($"My x position {x}");
        //Debug.Log($"My y position {y}");
    }

    private void Movement()
    {
        //calibrate for framerate later
        //if distance between (x and y) player and enemy is positive or negative
        //
        if (player.transform.position.x - transform.position.x >= 0)
            vx += 0.1f;

        else
            vx -= 0.1f;

        if (player.transform.position.y - transform.position.y >= 0)
            vy += 0.1f;
        else
            vy -= 0.1f;


        //float goodboy = vy += (playerY >= y) ? 0.1f : -0.1f; 
        //Transform by vx
        transform.Translate(vx * Time.deltaTime * Vector3.right);
        //transform by vy
        transform.Translate(vy * Time.deltaTime * Vector3.up);


        //dampen velocities (compound legacy sytle)

        vx *= coopersVar; //calibrate for framerate later
        vy *= coopersVar; //calibrate for framerate later

        //accelerate towards player (binary style)
        //calibrate for framerate later
    }
}