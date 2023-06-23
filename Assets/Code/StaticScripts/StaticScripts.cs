using UnityEngine;

/// <summary>
/// Generic classes for some situations
/// </summary>
public static class StaticScripts
{
    private static Camera _camera = Camera.main;
    public static bool VectorOutside(Vector3 vector3)
    {
        Vector3 playerOnScreenPos = _camera.WorldToScreenPoint(vector3);
        return (playerOnScreenPos.x < 0 || playerOnScreenPos.x > Screen.width ||
        playerOnScreenPos.y < 0 || playerOnScreenPos.y > Screen.height);
    }

    public static bool IfColliderHitted(Vector3 vector3, out Collider2D colliderHitted)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(vector3, 0.2f); 
        colliderHitted = hitColliders.Length > 0 ? hitColliders[hitColliders.Length-1] : null;
        return hitColliders.Length > 0;
    }

    public static Vector2 GetRandomVector()
    {
        int random = Random.Range(1, 5);
        //Debug.Log(random);
        switch (random)
        {
            case 1:
                return Vector2.up;
            case 2:
                return Vector2.left;
            case 3:
                return Vector2.down;
            case 4:
                return Vector2.right;
        }
        return Vector2.zero;
    }
}
