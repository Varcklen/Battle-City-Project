using UnityEngine;

public class PlayerFire : TankFire
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Fire();
    }
}
