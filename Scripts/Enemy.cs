using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private Rigidbody2D Rb;
    public GameObject hurdlePrefab;
    private float spawnhurdleRate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        // spawn hurdles
        Instantiate(hurdlePrefab, new Vector3(0, Random.Range(9, -9),0), hurdlePrefab.transform.rotation); 
        StartCoroutine(SpawnhurdleTarget());
     
    }
    IEnumerator SpawnhurdleTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnhurdleRate);
            Instantiate(hurdlePrefab, new Vector3(Random.Range(0, -9), Random.Range(9, -9)), transform.rotation); 

        }

    }

}
