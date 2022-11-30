using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public List<GameObject> bonus;
    private float speed = 5f;
    private Rigidbody2D playerRb;
    private Animator anim;
    public TextMeshProUGUI scoreText;
    private int score;
    public GameObject prefab;
    private float spawnRate = 5f;//spawn every one second
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SpawnFruits();
        score = 0;
    }

    void SpawnFruits() 
    {
        StartCoroutine(SpawnTarget());
        //  Instantiate(prefab, new Vector3(0,Random.Range(9,-9),0),prefab.transform.rotation);
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
        if (collision.gameObject.CompareTag("fruit1")) // when player collide with fruit 1, 5 score is added 
        {
            UpdateScore();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("fruit2")) 
        {
            UpdateScore();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Hurdle")) 
        {
            Destroy(gameObject);
            GameOver();
        }
      
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            // give randome number from list
            int index = Random.Range(0, bonus.Count);
            Instantiate(bonus[index],new Vector3(Random.Range(9,-9),Random.Range(9,-9)),transform.rotation); //spawn any object from prefabs

        }

    }
   
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
