using UnityEngine;
using TMPro;

namespace ViewNavigation
{
    public class CollapsiblePanel : MonoBehaviour
    {
        private const string HIDE_LABEL = "Hide Options";
        private const string SHOW_LABEL = "Show Options";

        private CameraMovementMouse mouseCamera;
        private bool mouseCameraIsActive;

        public RectTransform content;
        public TMP_Text buttonLabel;
        public bool collapsed;

        private void Awake()
        {
            mouseCamera = GameObject.FindObjectOfType<CameraMovementMouse>(includeInactive: true);
        }

        private void OnValidate() => ShowOrHideElements();

        public void ToggleCollapse()
        {
            collapsed = !collapsed;
            ShowOrHideElements();
        }

        private void ShowOrHideElements()
        {
            content.gameObject.SetActive(!collapsed);
            buttonLabel.text = collapsed ? SHOW_LABEL : HIDE_LABEL;
        }

        public void OnPoiinterEnter()
        {
            mouseCameraIsActive = mouseCamera.gameObject.activeSelf;
            mouseCamera.gameObject.SetActive(false);
        }

        public void OnPointerExit()
        {
            mouseCamera.gameObject.SetActive(mouseCameraIsActive);
        }
    }
}
