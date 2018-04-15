using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndCollision : MonoBehaviour {

    public Text myText;

    void Start() {
        myText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.transform.position = new Vector3(-23f, 25.95059f, 0f);
            BallController.rb.velocity = Vector3.zero;
            Debug.Log("Player in hole");
        }
        if (other.gameObject.CompareTag("lost")) {
            Debug.Log("lost");
            Destroy(other.gameObject);
			myText.gameObject.SetActive(true);
            myText.color = Color.red;
            if (BallController.turn) {
                myText.text = "Player 1 loose";
            }
            else {
                myText.text = "Player 2 loose";
            }
			Debug.Log(myText.text);
            BallController.playing = false;
        }
        if (other.gameObject.CompareTag("full")) {
			Destroy(other.gameObject);
            BallController.score1++;
            BallController.player1ExternText.text = "Player 1 : " + BallController.score1.ToString();
            Debug.Log("full : " + BallController.score1.ToString());
            if (BallController.score1 == 7) {
                BallController.playing = false;
                myText.gameObject.SetActive(true);
                myText.color = Color.red;
                myText.text = "Player 1 win";
            }
        }
        if (other.gameObject.CompareTag("half_full")) {
			Destroy(other.gameObject);
            BallController.score2++;
            BallController.player2ExternText.text = "Player 2 : " + BallController.score2.ToString();
            Debug.Log("half_full : " + BallController.score2.ToString());
            if (BallController.score2 == 7)
            {
                BallController.playing = false;
                myText.gameObject.SetActive(true);
                myText.color = Color.red;
                myText.text = "Player 2 win";
            }
        }

    }
}
