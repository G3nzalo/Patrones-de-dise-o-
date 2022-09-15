using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
        public bool IsPressed { get; private set; }
        public bool IsEnter { get; private set; }


        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressed = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsEnter = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsEnter = false;
        }
}

