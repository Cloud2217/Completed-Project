using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sword : MonoBehaviour
{
    public ParticleSystem particles;
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update(){
    }

// when colliding with enemy create particle effects, destroy the enemy, and add to score
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){
            Instantiate(particles, other.transform.position, Quaternion.LookRotation(Vector3.up));
            Destroy(other.gameObject);
            manager.addScore();
        }
    }
}
