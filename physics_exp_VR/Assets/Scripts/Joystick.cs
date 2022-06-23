using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    // Init
    private Image jsContainer;
    private Image joystick;
    public Vector3 InputDirection = Vector3.zero;

    void Start()
    {
        // Get the Component we attach this script (JoystickContainer)
        jsContainer = GetComponent<Image>();

        // Get the only one child component (Joystick)
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        // Get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            jsContainer.rectTransform,
            ped.position,
            ped.pressEventCamera,
            out position
        );

        float x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        float y = (position.y / jsContainer.rectTransform.sizeDelta.y);

        InputDirection = new Vector3(x, y, y);
        //print(InputDirection);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        // Define the area in which joystick can move around
        joystick.rectTransform.anchoredPosition = new Vector3(
            InputDirection.x * jsContainer.rectTransform.sizeDelta.x / 3,
            InputDirection.y * jsContainer.rectTransform.sizeDelta.y / 3
        );
    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        // If mouse release, the InputDirection variable have to return to Vector3(0.0, 0.0, 0.0);
        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}