using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D playerRb;
    private Animator anim;
    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerController();
    }

    private void playerController()

    {
        // when press space,it jumps
        if (Input.GetKeyDown("space"))
        {
            playerRb.velocity = new Vector3(0, 10, 0);
        }
        // player movement using arrow keys
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (playerRb.velocity.y > 1f)
        {
            anim.SetBool("Running", true);
        }

        else if (playerRb.velocity.y < 1f)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
    public void UpdateScore()  
    {
        score +=5;
        //update and tells current score
        scoreText.text = "Score :" + score;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Tile") ) // when player collide with tile 5 score is added 
        {
            UpdateScore();
        
        }
    }
 
}
