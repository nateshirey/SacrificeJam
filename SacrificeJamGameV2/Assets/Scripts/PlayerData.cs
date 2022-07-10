using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private int startHealth = 50;
    private Rigidbody2D rb;
    public int Health;
    // Start is called before the first frame update
    void Awake(){
    }
    void Start()
    {
        this.Health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
}