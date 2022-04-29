using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Position
{
    Left,
    Top,
    Right,
    Bottom
}

public class EnemyLogic : MonoBehaviour
{
    private Position _position;
    private float _minimalSpeed = 1f;
    private float _maximalSpeed = 4f;
    private float _speedX;
    private float _speedY;
    private float _timeToDestroy = 5f;

    public void Initialize(Position startPosition)
    {
        _position = startPosition;
        _speedX = Random.Range(_minimalSpeed, _maximalSpeed);
        _speedY = Random.Range(_minimalSpeed, _maximalSpeed);

        switch (_position)
        {
            case Position.Left:
                _speedY *= Random.Range(-1, 1);
                break;
            case Position.Top:
                _speedX *= Random.Range(-1, 1);
                _speedY *= -1;
                break;
            case Position.Right:
                _speedX *= -1;
                _speedY *= Random.Range(-1, 1);
                break;
            case Position.Bottom:
                _speedX *= Random.Range(-1, 1);
                break;
        }
    }

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(new Vector2(_speedX, _speedY) * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
