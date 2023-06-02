using System;
using UnityEngine;

public class GridMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rayLength = 0.6f;
    [SerializeField] private LayerMask walls;

    private Rigidbody _rigidbody;
    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private bool _moving;
    private float _percentage;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (_moving) {
            // Must follow this order of operations:
            _percentage += moveSpeed * Time.deltaTime;

            if (_percentage >= 1.0f) {
                _percentage = 1.0f;
            }

            Vector3 newPos = _startPosition + (_targetPosition - _startPosition) * _percentage;
            _rigidbody.MovePosition(newPos);

            if (_percentage >= 1.0f) {
                _moving = false;
                _percentage = 0f;
            }

            return;
        }

        Vector3 currentPosition = transform.position;
        if (Input.GetKeyDown(KeyCode.W)) {
            if (CanMove(Vector3.forward)) {
                _targetPosition = currentPosition + Vector3.forward;
                _startPosition = currentPosition;
                _moving = true;
            }
        } else if (Input.GetKeyDown(KeyCode.S)) {
            if (CanMove(Vector3.back)) {
                _targetPosition = currentPosition + Vector3.back;
                _startPosition = currentPosition;
                _moving = true;
            }
        } else if (Input.GetKeyDown(KeyCode.A)) {
            if (CanMove(Vector3.left)) {
                _targetPosition = currentPosition + Vector3.left;
                _startPosition = currentPosition;
                _moving = true;
            }
        } else if (Input.GetKeyDown(KeyCode.D)) {
            if (CanMove(Vector3.right)) {
                _targetPosition = currentPosition + Vector3.right;
                _startPosition = currentPosition;
                _moving = true;
            }
        }
    }

    private bool CanMove(Vector3 direction) {
        return !Physics.Raycast(transform.position, direction, rayLength, walls);
    }
}