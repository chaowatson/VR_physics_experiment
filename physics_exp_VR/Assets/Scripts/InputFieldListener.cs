
using TalesFromTheRift;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldListener : MonoBehaviour, ISelectHandler
{
    public InputField input;
    private OpenCanvasKeyboard script;

    public void Start()
    {
        script = input.GetComponent<OpenCanvasKeyboard>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        ((ISelectHandler)input).OnSelect(eventData);
        script.OpenKeyboard();
    }
}
