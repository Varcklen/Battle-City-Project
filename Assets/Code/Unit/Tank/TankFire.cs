using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TankMovement))]
public class TankFire : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _reloadTime = 0.5f;

    private TankMovement _tankMovement;
    private bool _onReload = false;
    private void Awake()
    {
        _tankMovement = GetComponent<TankMovement>();
    }

    protected void Fire()
    {
        if (_onReload) return;
        StartCoroutine(Reload());
        ProjectileThrow();
    }

    private IEnumerator Reload()
    {
        _onReload = true;

        float elapsedTime = 0;

        while (elapsedTime < _reloadTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _onReload = false;
    }

    private void ProjectileThrow()
    {
        Vector2 direction = _tankMovement.LastDirection;
        //Debug.Log("Fire!");

        GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().StartFly(GetComponent<Collider2D>(), direction);
    }
}
