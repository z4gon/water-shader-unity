using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ViewNavigation
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class ColorButton : MonoBehaviour
    {
        public UnityEvent<Color> OnColorSelected;

        private void Awake()
        {
            var button = GetComponent<Button>();
            var image = GetComponent<Image>();
            button.onClick.AddListener(() =>
            {
                OnColorSelected.Invoke(image.color);
            });
        }
    }
}
