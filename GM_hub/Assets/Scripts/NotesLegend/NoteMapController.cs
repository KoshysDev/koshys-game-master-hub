using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoteMapController : MonoBehaviour
{
    [SerializeField] private InputAction mapScroll;
    [SerializeField] private InputAction scroll;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float scrollAmount = 0.1f;

    private RectTransform mapTransfrom;
    private Vector3 curScroll = new(1f, 1f, 1f);

    private float maxScroll = 10;

    void Start()
    {
        mapTransfrom = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse2)) MapMove();

        if(scroll.triggered) MapScroll();
    }

    void MapScroll()
    {   
        float scrollDelta = scroll.ReadValue<Vector2>().y * scrollAmount;

        // Calculate the new scale based on the scroll input
        Vector3 newScale = mapTransfrom.localScale + Vector3.one * scrollDelta;

        // Clamp the scale within the specified range
        newScale.x = Mathf.Clamp(newScale.x, 0.1f, maxScroll);
        newScale.y = Mathf.Clamp(newScale.y, 0.1f, maxScroll);

        // Apply the new scale to the RectTransform
        mapTransfrom.localScale = newScale;
    }

    void MapMove()
    {
        var moveInput = mapScroll.ReadValue<Vector2>() * scrollSpeed * Time.deltaTime;

        mapTransfrom.anchoredPosition += moveInput;
    }

    void OnEnable()
    {
        mapScroll.Enable();
        scroll.Enable();
    }

    void OnDisable()
    {
        mapScroll.Disable();
        scroll.Disable();
    }
}
