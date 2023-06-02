using UnityEngine;

namespace Script {
    public class ChangeMaterial : MonoBehaviour {
        [SerializeField] private Material[] materials;
        private Renderer _renderer;

        private void Start() {
            _renderer = GetComponent<Renderer>();
            ChangeRandomly();
        }

        public void ChangeRandomly() {
            _renderer.material = materials[Random.Range(0, materials.Length)];
        }
    }
}