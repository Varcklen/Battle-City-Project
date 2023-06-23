using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private readonly float _projectileSpeed = 7f;

    private int _faction;
    private Collider2D _ownerCollider;
    private Vector2 _direction;
    private Camera _camera;

    public void StartFly(Collider2D ownerCollider, Vector2 direction)
    {
        _camera = Camera.main;
        _ownerCollider = ownerCollider;
        _direction = direction;
        _faction = ownerCollider.GetComponent<Unit>().Faction;
        StartCoroutine(ProjectileFly());
    }

    private IEnumerator ProjectileFly()
    {
        while (StaticScripts.VectorOutside(transform.position) == false)
        {
            transform.Translate(_direction * _projectileSpeed * Time.deltaTime);
            yield return null;
            if (StaticScripts.IfColliderHitted(transform.position, out Collider2D collider))
            {
                OnCollide(collider);
            }
        }
        Destroy(gameObject);
    }

    private void OnCollide(Collider2D collision)
    {
        //Debug.Log($"Collided with: {collision.gameObject.name}");
        if (collision == _ownerCollider) return;
        if (collision == gameObject.GetComponent<Collider2D>()) return;

        var unit = collision.GetComponent<Unit>();
        if (unit == null) return;
        if (_faction == unit.Faction) return;

        unit.TakeDamage();
        Destroy(gameObject);
   }
}
