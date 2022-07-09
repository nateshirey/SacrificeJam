using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int startHealth = 50;

    private int playerHealth;
    public Vector2 location;
    public List<Vector2> drops;
    public GameObject oilSplotOBJ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
