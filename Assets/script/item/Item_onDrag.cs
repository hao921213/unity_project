using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
public class Item_onDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform o_parent;
    public bag player_bag;
    private int current_id;
    public void OnBeginDrag(PointerEventData eventData)
    {
        o_parent=transform.parent;
        current_id=o_parent.GetComponent<slot>().slot_id;
        transform.SetParent(transform.parent.parent);
        transform.position=eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts=false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position=eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.name=="Item_Image"){
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position=eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            var temp=player_bag.itemlist[current_id];
            player_bag.itemlist[current_id]=player_bag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slot_id];
            player_bag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slot_id]=temp;

            eventData.pointerCurrentRaycast.gameObject.transform.parent.position=o_parent.position; 
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(o_parent);
            GetComponent<CanvasGroup>().blocksRaycasts=true;
            return;
        }
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position=eventData.pointerCurrentRaycast.gameObject.transform.position;
        player_bag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slot_id]=player_bag.itemlist[current_id];
        player_bag.itemlist[current_id]=null;
        GetComponent<CanvasGroup>().blocksRaycasts=true;
    }

}
