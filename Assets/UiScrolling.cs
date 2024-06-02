using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiScrolling : MonoBehaviour
{
    public GameObject currentSelectedObject; // Das aktuell ausgewählte UI-Element
    private bool isMouseDown;

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            if (currentSelectedObject == null)
            {
                currentSelectedObject = EventSystem.current.currentSelectedGameObject;
                if (currentSelectedObject == null)
                {
                    SelectFirstUIElement();
                }
            }
            else
            {
                SelectNextUIElement(scrollInput);
            }
        }

        if (Input.GetMouseButtonDown(2)) // Mausrad-Taste
        {
            ClickSelectedButton();
        }
    }

    private void SelectFirstUIElement()
    {
        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
        currentSelectedObject = EventSystem.current.currentSelectedGameObject;
    }

    private void SelectNextUIElement(float scrollInput)
    {
        Selectable nextUIElement = null;
        if (scrollInput > 0)
        {
            nextUIElement = currentSelectedObject.GetComponent<Selectable>().FindSelectableOnUp();
        }
        else if (scrollInput < 0)
        {
            nextUIElement = currentSelectedObject.GetComponent<Selectable>().FindSelectableOnDown();
        }

        if (nextUIElement != null)
        {
            currentSelectedObject = nextUIElement.gameObject;
            EventSystem.current.SetSelectedGameObject(currentSelectedObject);
        }
    }

    private void ClickSelectedButton()
    {
        if (currentSelectedObject != null)
        {
            Button button = currentSelectedObject.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.Invoke();
            }
        }
    }
}
