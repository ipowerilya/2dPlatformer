using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlMove : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    public Rigidbody2D rb;
    public float move;
    public bool facingRight = true;
    public float spawnX, spawnY;
    public int score;
    public Text ScoreText;
    public string LevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnX = transform.position.x;
        spawnY = transform.position.y;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;
        move = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        if (move > 0 && !facingRight)
            flip();
        if (move < 0 && facingRight)
            flip();
    }
    public void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DieCollider")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            score = 0;
        }
        if (col.gameObject.tag == "Star")
        {
            Destroy(col.gameObject);
            score++;
        }
        if(col.gameObject.tag == "LvL")
        {
            SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Single);
        }
    }
}
