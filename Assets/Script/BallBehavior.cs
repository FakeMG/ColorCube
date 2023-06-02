using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Script {
    public class BallBehavior : MonoBehaviour {
        [SerializeField] private BoxCollider ground;
        [SerializeField] private UnityEvent onPlayerTriggerEnter;

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                StartCoroutine(RepositionRandomly());
                onPlayerTriggerEnter?.Invoke();
            }
        }

        private IEnumerator RepositionRandomly() {
            var bounds = ground.bounds;

            float newX = Random.Range(bounds.min.x, bounds.max.x);
            newX = RoundToNearestHalf(newX);

            float newZ = Random.Range(bounds.min.z, bounds.max.z);
            newZ = RoundToNearestHalf(newZ);

            Vector3 randomPosition = new Vector3(newX, transform.position.y, newZ);
            transform.localScale = Vector3.zero;

            yield return new WaitForSeconds(1f);
            transform.localScale = Vector3.one;
            transform.position = randomPosition;
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