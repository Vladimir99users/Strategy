using UnityEngine;

namespace Assets.Scripts.Service
{
    public class CameraService : MonoBehaviour
    {
        [SerializeField] private float stepCamera;
        [SerializeField] private Camera camera;

        private Vector2 direction;
        private ICameraController controller;
        public void Initialize(ICameraController controller)
        {
            this.controller = controller;
            this.controller.OnCameraMoved += GetDirection;
            camera = Camera.main;
        }

        private void OnDisable()
        {
            controller.OnCameraMoved -= GetDirection;
        }

        private void GetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        private void LateUpdate()
        {
            if (direction == Vector2.zero)
                return;
            MoveCamera();
        }

        private void MoveCamera()
        {
            var moveDirection = new Vector3(direction.x, 0, direction.y);
            camera.transform.position += moveDirection * stepCamera * Time.deltaTime;
        }

    }
}
