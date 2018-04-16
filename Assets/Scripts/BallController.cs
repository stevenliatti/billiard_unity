using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public static int score1 = 0;
    public static int score2 = 0;
    public static Rigidbody rb;
    public static bool turn;
    public static Text player1ExternText;
    public static Text player2ExternText;
    public static bool playing;

	public Text player1Text;
	public Text player2Text;
    public float moveVertical;
    public float speed;
    public Vector3 playerPosition;
    public Vector3 endLine;
    public Vector3 lineSize;
    public LineRenderer line;
    public int maxForce;

    void Start()
    {
        speed = 100;
        maxForce = 5;
        moveVertical = 0;
        turn = false;
        playing = true;
        rb = GetComponent<Rigidbody>();
        lineSize = new Vector3(10.0f, 0.0f, 0.0f);
        playerPosition = rb.transform.position;
        endLine = playerPosition + lineSize;
        line = GetComponent<LineRenderer>();
        player1Text.text = "Player 1 (full) : 0";
        player1Text.color = Color.red;
        player2Text.text = "Player 2 (half_full) : 0";
        player1ExternText = player1Text;
        player2ExternText = player2Text;
    }

    void FixedUpdate()
    {
        if (playing) {
            playerPosition = rb.transform.position;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Quaternion rotate = Quaternion.Euler(0, -2, 0);
                lineSize = rotate * lineSize;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Quaternion rotate = Quaternion.Euler(0, 2, 0);
                lineSize = rotate * lineSize;
            }

            endLine = playerPosition + lineSize;
            moveVertical += Input.GetAxis("Vertical");

            if (moveVertical >= maxForce)
            {
                moveVertical = maxForce;
            }

            endLine += lineSize.normalized * moveVertical;
            line.SetPosition(0, playerPosition);
            line.SetPosition(1, endLine);

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce((endLine - playerPosition) * speed);
                turn = !turn;

                if (turn)
                {
                    player1Text.color = Color.red;
                    player2Text.color = Color.white;
                }
                else
                {
                    player2Text.color = Color.red;
                    player1Text.color = Color.white;
                }
            }
            if (Input.GetKey(KeyCode.RightControl))
            {
                rb.transform.position = new Vector3(-23f, 25.95059f, 0f);
            }
        }
    }
}
