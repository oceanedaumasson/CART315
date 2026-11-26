using UnityEngine;
using UnityEngine.EventSystems;

public class ClueClick : MonoBehaviour, IPointerClickHandler
{
    public bool isAnswer;
    public string clueID;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isAnswer)
        {
            if (ClueManager.Instance.TryResolve(clueID))
                gameObject.SetActive(false); // So it can't be clicked twice
        }
        else
        {
            ClueManager.Instance.PickUp(clueID);
        }
    }

}
