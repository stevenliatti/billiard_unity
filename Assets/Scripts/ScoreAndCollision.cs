using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndCollision : MonoBehaviour {

    void Update() {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.transform.position = new Vector3(-23f, 25.95059f, 0f);
            BallController.rb.velocity = Vector3.zero;
            Debug.Log("Player in hole");
        }
        if (other.gameObject.CompareTag("full")) {
            BallController.score1++;
            Debug.Log("full : " + BallController.score1.ToString());
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("half_full")) {
            BallController.score2++;
            Debug.Log("half_full : " + BallController.score2.ToString());
            Destroy(other.gameObject);
        }

    }
}
