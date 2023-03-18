using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHight;
    [SerializeField] private float _minHight;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void MoveUp()
    {
        if (_targetPosition.y < _maxHight)
            SetNextPosition(_stepSize);
    }

    public void MoveDown()
    {
        if (_targetPosition.y > _minHight)
            SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(transform.position.x, transform.position.y + stepSize);
    }
}
