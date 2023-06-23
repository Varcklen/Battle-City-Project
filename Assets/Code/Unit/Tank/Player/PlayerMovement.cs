using UnityEngine;

public class PlayerMovement : TankMovement
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            MovePlayer(Vector3.up);

        if (Input.GetKey(KeyCode.A))
            MovePlayer(Vector3.left);

        if (Input.GetKey(KeyCode.S))
            MovePlayer(Vector3.down);

        if (Input.GetKey(KeyCode.D))
            MovePlayer(Vector3.right);
    }
}
