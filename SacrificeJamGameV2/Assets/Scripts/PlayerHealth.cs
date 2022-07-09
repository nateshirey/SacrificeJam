using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int startHealth = 50;
    private Rigidbody2D rb
    private int playerHealth;
    public List<Vector2> drops;
    public GameObject oilSplotOBJ;
    // Start is called before the first frame update
    void Start()
    {
        drops.append(rb.location)
    }

    // Update is called once per frame
    void Update()
    {

    }
}
