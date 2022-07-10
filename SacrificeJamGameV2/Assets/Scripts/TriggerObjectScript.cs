using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectScript : MonoBehaviour
{
    private bool blownup = false;
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
        if(!blownup){
            blownup = true;
            this.GetComponent<SpriteRenderer>().color = new Color(0.1f,0.3f,1f,1);
        }
    }
    
}
