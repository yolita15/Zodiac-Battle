using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed = 0.8f;
    private bool isDead;
    private bool gameStarted;
    private Vector2 originalPosition;
    private GameObject startButton;


    public void Start()
    {

        this.rb = this.GetComponent<Rigidbody2D>();
        this.originalPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        this.startButton = GameObject.Find("PlayButton");
        this.Speed = 0;
        this.rb.gravityScale = 0;
    }


    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isDead)
            {
                if (!this.gameStarted)
                {
                    var renderer = startButton.GetComponent<SpriteRenderer>();
                    renderer.enabled = false;
                    this.Speed = 10;
                    this.rb.gravityScale = 1;
                }
            }
            else
            {
                Application.LoadLevel("ZodiacBattle");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !this.isDead)
        {
            this.transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !this.isDead)
        {
            this.transform.position += new Vector3(1, 0, 0);
        }

    }
    public void FixedUpdate()
    {
        this.rb.AddForce(new Vector2(0, this.Speed));
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            this.isDead = true;
            var renderer = startButton.GetComponent<SpriteRenderer>();
            renderer.enabled = true;
            Destroy(this.rb);


            var startButtonX = Camera.main.transform.position.x;
            var startButtonY = Camera.main.transform.position.y;

            var startButtonPosition = this.startButton.transform.position;
            startButtonPosition.x = startButtonX;
            startButtonPosition.y = startButtonY;
            this.startButton.transform.position = startButtonPosition;
        }
    }
}
