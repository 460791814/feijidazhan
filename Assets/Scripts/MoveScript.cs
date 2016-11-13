using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direct = new Vector2(-1, 0);
    private Vector3 move;
    // Update is called once per frame
    void Update()
    {

        move = new Vector3(direct.x * speed.x, direct.y * speed.y, 0);
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = move;
    }
}
