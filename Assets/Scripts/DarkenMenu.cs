using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class DarkenMenu : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public RectTransform sideMenuRectTransform;
    private float height;
    private float startPositionY;
    private float startingAnchoredPositionY;
    private bool isOpen = false;

    private float defaultY;
    private bool isDragging = false;


    // Start is called before the first frame update
    void Start()
    {
        height = Screen.height;
        defaultY = sideMenuRectTransform.anchoredPosition.y;
    }

    public void OnDrag(PointerEventData eventData) {
        float newY = Mathf.Clamp(startingAnchoredPositionY - (startPositionY - eventData.position.y), GetMinPosition(), GetMaxPosition());
        sideMenuRectTransform.anchoredPosition = new Vector2(sideMenuRectTransform.anchoredPosition.x, newY);

        isDragging = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        //StopAllCoroutines();
        startPositionY = eventData.position.y;
        startingAnchoredPositionY = sideMenuRectTransform.anchoredPosition.y;
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (isDragging)
        {
            StartCoroutine(HandleMenuSlide(0.37f, sideMenuRectTransform.anchoredPosition.y, isAfterHalfPoint() ? GetMinPosition() : GetMaxPosition()));
        }
        else
        {
            // Toggle the menu open or closed when clicked
            float targetPosition = isOpen ? GetMinPosition() : GetMaxPosition();
            StartCoroutine(HandleMenuSlide(0.37f, sideMenuRectTransform.anchoredPosition.y, targetPosition));
            isOpen = !isOpen;
        }
        isDragging = false;
    }

    

    private bool isAfterHalfPoint() {
        if (!isOpen)
        {
            isOpen = true;
            return sideMenuRectTransform.anchoredPosition.y < (height / 16);
        }
        else
        {
            isOpen = false;
            return sideMenuRectTransform.anchoredPosition.y < (height - (1f));
        }
    }

    private float GetMinPosition() {
        return defaultY;
    }

    private float GetMaxPosition() {
        return height * 1.1f;
    }

    private IEnumerator HandleMenuSlide(float slideTime, float startingY, float targetY)
    {
        float elapsedTime = 0f;
        while (elapsedTime < slideTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / slideTime); // Normalize time
            float easedT = EaseInOutQuad(t); // Apply easing function
            sideMenuRectTransform.anchoredPosition = new Vector2(sideMenuRectTransform.anchoredPosition.x, Mathf.Lerp(startingY, targetY, easedT));
            yield return null;
        }
        // Ensure the menu reaches the exact target position after the animation completes
        sideMenuRectTransform.anchoredPosition = new Vector2(sideMenuRectTransform.anchoredPosition.x, targetY);
    }

    // Quadratic easing function (ease-in and ease-out)
    private float EaseInOutQuad(float t)
    {
        return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
    }

    
}
