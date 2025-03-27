using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Service
{
    public class InputService : MonoBehaviour
    {
        private InputSystem_Actions inputScheme;
        public void Initialize()
        {
            OnInitialize();
        }

        protected void OnInitialize()
        {
            inputScheme = new InputSystem_Actions();
            inputScheme.Enable();

            inputScheme.Player.Click.performed += PlayerMove;
            inputScheme.Camera.Move.performed += CameraMove;
        }
        private void PlayerMove(InputAction.CallbackContext obj)
        {
            Debug.Log($"Mouse position = {inputScheme.Player.PositionMouse.ReadValue<Vector2>()}");
        }
        private void CameraMove(InputAction.CallbackContext obj)
        {
            Debug.Log($"Mouse position = {obj.ReadValue<Vector2>()}");
        }

    }
}
