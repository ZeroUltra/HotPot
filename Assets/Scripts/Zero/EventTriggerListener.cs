using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class EventTriggerListener : EventTrigger
{
    public delegate void VoidDelegate<T>(T eventData);
    public VoidDelegate<PointerEventData> onClick;
    public VoidDelegate<PointerEventData> onDown;
    public VoidDelegate<PointerEventData> onEnter;
    public VoidDelegate<PointerEventData> onExit;
    public VoidDelegate<PointerEventData> onUp;
    public VoidDelegate<BaseEventData> onSelect;
    public VoidDelegate<BaseEventData> onUpdateSelect;
    public VoidDelegate<AxisEventData> onMove;

    static public EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null) listener = go.AddComponent<EventTriggerListener>();
        return listener;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) onClick(eventData);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null) onDown(eventData);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onEnter != null) onEnter(eventData);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onExit != null) onExit(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null) onUp(eventData);
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) onSelect(eventData);
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelect != null) onUpdateSelect(eventData);
    }
    public override void OnMove(AxisEventData eventData)
    {
        if (onMove != null) onMove(eventData);
    }

}
