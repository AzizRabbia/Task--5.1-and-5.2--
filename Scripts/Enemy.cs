using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D Rb;
    public GameObject hurdlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Instantiate(hurdlePrefab, new Vector3(0, Random.Range(9, -9),0), hurdlePrefab.transform.rotation);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
