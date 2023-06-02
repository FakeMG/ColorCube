using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Script {
    public class BallBehavior : MonoBehaviour {
        [SerializeField] private BoxCollider ground;
        [SerializeField] private UnityEvent onPlayerTriggerEnter;
        [SerializeField] private UnityEvent onLose;

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player") && transform.localScale == Vector3.one) {
                Renderer object1Renderer = other.GetComponent<Renderer>();
                Renderer object2Renderer = GetComponent<Renderer>();

                if (object1Renderer.material.color == object2Renderer.material.color) {
                    StartCoroutine(RepositionRandomly());
                    onPlayerTriggerEnter?.Invoke();
                } else {
                    onLose?.Invoke();
                }
            }
        }

        private IEnumerator RepositionRandomly() {
            var randomPosition = GetRandomPositionInBound();
            while (!IsPositionValid(randomPosition)) {
                randomPosition = GetRandomPositionInBound();
            }

            randomPosition.y = transform.position.y;
            transform.localScale = Vector3.zero;

            yield return new WaitForSeconds(1f);
            transform.localScale = Vector3.one;
            transform.position = randomPosition;
        }

        private bool IsPositionValid(Vector3 position) {
            position.y = transform.position.y;
            return !Physics.Raycast(position + Vector3.up, Vector3.down, 0.6f);
        }

        private Vector3 GetRandomPositionInBound() {
            var bounds = ground.bounds;

            float newX = Random.Range(bounds.min.x, bounds.max.x);
            newX = RoundToNearestHalf(newX);

            float newY = Random.Range(bounds.min.y, bounds.max.y);
            newY = RoundToNearestHalf(newY);

            float newZ = Random.Range(bounds.min.z, bounds.max.z);
            newZ = RoundToNearestHalf(newZ);

            return new Vector3(newX, newY, newZ);
        }

        private float RoundToNearestHalf(float value) {
            var roundedValue = Mathf.Round(value * 2f) / 2f;

            if ((roundedValue / 0.5) % 2 == 0) {
                roundedValue -= 0.5f;
            }

            return roundedValue;
        }
    }
}