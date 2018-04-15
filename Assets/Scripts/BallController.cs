using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour {

    public static int score1 = 0;
    public static int score2 = 0;
	
    public static Rigidbody rb;

    public float moveVertical;
    public float speed;
    public Vector3 playerPosition;
    public Vector3 endLine;
    public Vector3 lineSize;
    public LineRenderer line;


    void Start()
    {
        speed = 10;
        moveVertical = 0;
        rb = GetComponent<Rigidbody>();
        lineSize = new Vector3(10.0f, 0.0f, 0.0f);
        playerPosition = rb.transform.position;
        endLine = playerPosition + lineSize;
        line = gameObject.AddComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
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
        endLine += lineSize.normalized * moveVertical;
        line.SetPosition(0, playerPosition);
        line.SetPosition(1, endLine);

        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce((endLine - playerPosition) * speed);
        }
    }
}
