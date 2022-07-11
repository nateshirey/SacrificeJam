using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public bool playerBlownup = false;
    public GameObject player;
    public PlayerData playerData;
    public Rigidbody2D playerRB;
    public float distance = 3;
    public float explodeDelay = 0.1f;
    public float explodeRadius = 0.4f;
    public List<GameObject> interactables;
    public List<Vector2> drops;
    public GameObject oilSplotOBJ;
    public List<GameObject> oilSplots;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        playerData = player.GetComponent<PlayerData>();
        interactables = new List<GameObject>(GameObject.FindGameObjectsWithTag("Interactable"));
        drops.Add(playerRB.position);
    }
    void Awake(){
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        interactables = new List<GameObject>(GameObject.FindGameObjectsWithTag("Interactable"));
    }
    // Update is called once per frame
    void Update()
    {
        if((playerRB.position-drops[drops.Count-1]).magnitude>distance & playerData.Health>0){
            playerData.Health -=1;
            oilSplots.Add(Instantiate(oilSplotOBJ, drops[drops.Count-1], Quaternion.identity));
            if(playerData.Health<=0 & !playerBlownup){
                playerBlownup = true;
                StartCoroutine(Explode());

            }
            else{
                drops.Add(playerRB.position);
            }
        }
        else if(playerData.Health<=0 & !playerBlownup){
            playerBlownup = true;
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
                for(int j = 0; j<interactables.Count; j++){
                    Vector2 InteractableVector = new Vector2(interactables[j].transform.position.x,interactables[j].transform.position.y);
                    if(((drops[tempList[i]]-InteractableVector).magnitude<explodeRadius)){
                        interactables[j].GetComponentInChildren<TriggerObjectScript>().Explode();
                    }
                }
            }
            
            yield return new WaitForSeconds(explodeDelay);
        }
    }
}
