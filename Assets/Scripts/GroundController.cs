using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector3(-23f, 25.95059f, 0f);
            BallController.rb.velocity = Vector3.zero;
            Debug.Log("Player touch the ground");
        }
    }
}
