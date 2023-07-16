using UnityEngine;
using UnityEngine.InputSystem;

namespace ViewNavigation
{
    public class CameraMovementMouse : CameraMovement
    {
        private bool isOrbiting = false;
        private bool isPanning = false;

        private void OnPointerDelta(InputValue value)
        {
            orbitAmount = isOrbiting ? value.Get<Vector2>() * -1.0f : Vector2.zero;
            panAmount = isPanning ? value.Get<Vector2>() * -1.0f : Vector2.zero;
        }

        private void OnOrbitStart(InputValue value)
        {
            isOrbiting = value.isPressed;
        }

        private void OnPanStart(InputValue value)
        {
            isPanning = value.isPressed;
        }

        private void OnZoom(InputValue value)
        {
            zoomAmount = value.Get<float>() * -1.0f;
        }
    }
}
