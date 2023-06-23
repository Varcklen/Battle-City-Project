using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ChangeSprite))]
public class TankMovement : MonoBehaviour
{
    [SerializeField] private float _timeToMove = 0.2f;

    public Vector3 LastDirection { get; private set; } = Vector3.up;

    private bool _isMoving;
    private Vector3 _orinalPos, _targetPos;
    private ChangeSprite _changeSprite;

    private void Awake()
    {
        _changeSprite = GetComponent<ChangeSprite>();
    }

    protected void MovePlayer(Vector3 direction)
    {
        if (_isMoving) return;

        UpdateDirection(direction);

        _targetPos = transform.position + direction;
        if (StaticScripts.VectorOutside(_targetPos)) return;
        if (StaticScripts.IfColliderHitted(_targetPos, out Collider2D collider)) return;

        StartCoroutine(MovePlayerCoroutine(direction));
    }

    private IEnumerator MovePlayerCoroutine(Vector3 direction)
    {
        _isMoving = true;

        float elapsedTime = 0;

        _orinalPos = transform.position;
        _targetPos = _orinalPos + direction;

        while (elapsedTime < _timeToMove)
        {
            transform.position = Vector3.Lerp(_orinalPos, _targetPos, elapsedTime / _timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = _targetPos;

        _isMoving = false;
    }

    private void UpdateDirection(Vector3 direction)
    {
        LastDirection = direction;
        _changeSprite.SetSprite(direction);
    }
}
