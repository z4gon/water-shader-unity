using UnityEngine;

namespace ViewNavigation
{
    public class NavigationHUD : MonoBehaviour
    {
        public RectTransform mouseUI;
        public RectTransform joystickUI;

        private CameraMovementMouse mouseCamera;
        private CameraMovementJoystick joystickCamera;

        private void Awake()
        {
            mouseCamera = GameObject.FindObjectOfType<CameraMovementMouse>(includeInactive: true);
            joystickCamera = GameObject.FindObjectOfType<CameraMovementJoystick>(includeInactive: true);

            UseJoystick(false);
        }

        public void UseJoystick(bool use)
        {
            mouseUI.gameObject.SetActive(!use);
            joystickUI.gameObject.SetActive(use);

            mouseCamera.gameObject.SetActive(!use);
            joystickCamera.gameObject.SetActive(use);
        }

        public void Zoom(int amount)
        {
            joystickCamera.SetZoomAmount(amount);
        }
    }
}

