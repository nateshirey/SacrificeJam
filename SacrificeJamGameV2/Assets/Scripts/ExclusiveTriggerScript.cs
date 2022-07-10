using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclusiveTriggerScript : TriggerObjectScript
{
    public Vector3 partnerObjectRelativeLocation;
    public GameObject partnerPrefab;
    public GameObject partnerOBJ;
    
    // Start is called before the first frame update
    void Start()
    {   
        this.partnerOBJ = Instantiate(partnerPrefab, this.transform.position + partnerObjectRelativeLocation, Quaternion.identity);
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = 0.75f;
        this.partnerOBJ.GetComponentInChildren<SpriteRenderer>().color = c;


    }

    // Update is called once per frame
    void Update()
    {
        if (this.partnerOBJ.GetComponentInChildren<TriggerObjectScript>().blownup&!blownup){
            this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1);
        }
    }
    
    public override void Explode()
    {
        if(!blownup & !this.partnerOBJ.GetComponentInChildren<TriggerObjectScript>().blownup){
            blownup = true;
            this.GetComponent<SpriteRenderer>().color = new Color(0.1f,0.3f,1f,1);
            this.partnerOBJ.GetComponentInChildren<TriggerObjectScript>().Explode();
            
        }
    }
}


