using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class HoverClickEnlarger : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler
{
    [Tooltip("Scale multiplier when pointer hovers")]
    public float hoverScaleFactor = 1.1f;
    [Tooltip("Scale multiplier when pointer clicks")]
    public float clickScaleFactor = 1.2f;

    private Vector3 _originalScale;
    private RectTransform _rectTransform;
    private bool _isHovered;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalScale = _rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isHovered = true;
        _rectTransform.localScale = _originalScale * hoverScaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isHovered = false;
        _rectTransform.localScale = _originalScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform.localScale = _originalScale * clickScaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // return to hover scale if still hovered, otherwise back to original
        _rectTransform.localScale = _isHovered
            ? _originalScale * hoverScaleFactor
            : _originalScale;
    }
}
