using UnityEngine;
using UnityEngine.InputSystem;

namespace ViewNavigation
{
    [RequireComponent(typeof(PlayerInput))]
    public abstract class CameraMovement : MonoBehaviour
    {
        new private Camera camera;

        [Header("Speed")]
        public float orbitSpeed = 30f;
        public float panSpeed = 2.5f;
        public float zoomSpeed = 2.5f;
        protected Plane? floorPlane;
        protected Vector2 panAmount = Vector2.zero;
        protected Vector2 orbitAmount = Vector2.zero;
        protected float zoomAmount = 0.0f;

        private void Awake()
        {
            camera = GameObject.FindObjectOfType<Camera>();
            PositionPivot();
        }

        private void Update()
        {
            HandlePan();
            HandleOrbit();
            HandleZoom();
        }

        private void HandlePan()
        {
            if (panAmount == Vector2.zero) { return; }

            var direction = camera.transform.right * panAmount.x + camera.transform.up * panAmount.y;

            camera.transform.position += (direction * panSpeed * Time.deltaTime);
            PositionPivot();
        }

        private void HandleOrbit()
        {
            if (orbitAmount == Vector2.zero) { return; }

            camera.transform.RotateAround(transform.position, Vector3.up, -1.0f * orbitAmount.x * orbitSpeed * Time.deltaTime);
            camera.transform.RotateAround(transform.position, camera.transform.right, orbitAmount.y * orbitSpeed * Time.deltaTime);
        }

        private void HandleZoom()
        {
            if (zoomAmount == 0.0f) { return; }

            var direction = camera.transform.forward;
            camera.transform.position += (direction * zoomAmount * Time.deltaTime);
        }

        private void PositionPivot()
        {
            if (floorPlane == null)
            {
                floorPlane = new Plane(new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0));
            }

            var distance = 0.0f;

            var ray = new Ray(camera.transform.position, camera.transform.forward);

            if (floorPlane.Value.Raycast(ray, out distance))
            {
                transform.position = ray.GetPoint(distance);
            }
        }

        private void OnDrawGizmos()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(transform.position, 0.06f);

            // camera tether and frustum
            if (camera != null)
            {
                Gizmos.DrawLine(transform.position, camera.transform.position);
                var prevMatrix = Gizmos.matrix;
                Gizmos.matrix = camera.transform.localToWorldMatrix;
                Gizmos.DrawFrustum(Vector3.zero, camera.fieldOfView, 15, camera.nearClipPlane, camera.aspect);
                Gizmos.matrix = prevMatrix;
            }
        }
    }
}
