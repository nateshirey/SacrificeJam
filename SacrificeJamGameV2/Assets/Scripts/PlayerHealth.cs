using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int startHealth = 50;
    
    //This is a flag to keep from repeating the blow up
    private int blownup = 0;
    private Rigidbody2D rb;
    private int playerHealth;
    public float distance = 3;
    public float explodeDelay = 0.1f;
    public float explodeRadius = 0.4f;
    public List<Vector2> drops;
    public GameObject oilSplotOBJ;
    public List<GameObject> oilSplots;
    // Start is called before the first frame update
    void Awake(){
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerHealth = startHealth;
        drops.Add(rb.position);
    }

    // Update is called once per frame
    void Update()
    {
        if((rb.position-drops[drops.Count-1]).magnitude>distance & playerHealth>0){
            oilSplots.Add(Instantiate(oilSplotOBJ, drops[drops.Count-1], Quaternion.identity));
            playerHealth -=1;
            if(playerHealth<=0 & blownup ==0){
                blownup = 1;
                StartCoroutine(Explode());

            }
            else{
                drops.Add(rb.position);
            }
        }
        else if(playerHealth<=0& blownup ==0){
            blownup = 1;
            StartCoroutine(Explode());

        }
    }
    IEnumerator Explode()
    {
        List<int> activeSplots = new List<int>();
        List<int> explodingSplots = new List<int>();
        for( int i =0; i<drops.Count-1; i++){
            activeSplots.Add(i);
        }
        explodingSplots.Add(oilSplots.Count-1);
        while(explodingSplots.Count>0){
            List<int> tempList = new List<int>(explodingSplots);
            explodingSplots = new List<int>();
            for(int i =0; i<tempList.Count; i++){        
                oilSplots[tempList[i]].GetComponentInChildren<OilSplotScript>().Explode();
                for(int j = 0; j<activeSplots.Count; j++){
                    if((drops[tempList[i]]-drops[activeSplots[j]]).magnitude<explodeRadius){
                        explodingSplots.Add(activeSplots[j]);
                        activeSplots.Remove(activeSplots[j]);
                    }
                }
            }
            
            yield return new WaitForSeconds(explodeDelay);
        }
    }
}