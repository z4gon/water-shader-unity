using UnityEngine;

namespace ViewNavigation
{
    public class ResetView : MonoBehaviour
    {
        new private Camera camera;
        private CameraMovementMouse mouseCamera;
        private CameraMovementJoystick joystickCamera;
        private Vector3 initialMouseCamPos;
        private Vector3 initialJoystickCamPos;
        private Vector3 initialCamPos;
        private Quaternion initialCamRot;

        private void Awake()
        {
            camera = GameObject.FindObjectOfType<Camera>();
            mouseCamera = GameObject.FindObjectOfType<CameraMovementMouse>(includeInactive: true);
            joystickCamera = GameObject.FindObjectOfType<CameraMovementJoystick>(includeInactive: true);
            SaveInitialView();
        }

        private void SaveInitialView()
        {
            initialMouseCamPos = mouseCamera.transform.position;
            initialJoystickCamPos = joystickCamera.transform.position;
            initialCamPos = camera.transform.position;
            initialCamRot = camera.transform.rotation;
        }

        public void LoadInitialView()
        {
            mouseCamera.transform.position = initialMouseCamPos;
            joystickCamera.transform.position = initialJoystickCamPos;
            camera.transform.position = initialCamPos;
            camera.transform.rotation = initialCamRot;
        }
    }
}
