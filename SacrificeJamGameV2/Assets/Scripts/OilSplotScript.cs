using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSplotScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1,0.3f,0.1f,1);
    }
}
