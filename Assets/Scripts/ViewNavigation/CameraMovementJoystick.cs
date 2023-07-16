using UnityEngine;
using UnityEngine.InputSystem;

namespace ViewNavigation
{
    public class CameraMovementJoystick : CameraMovement
    {
        private void OnPan(InputValue value) => panAmount = value.Get<Vector2>() * -1.0f;
        private void OnOrbit(InputValue value) => orbitAmount = value.Get<Vector2>() * -1.0f;

        public void SetZoomAmount(int amount)
        {
            zoomAmount = amount;
        }
    }
}
