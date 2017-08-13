using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public LayerMask movementMask;

    Camera playerCam;

    Player player;

    void Start()
    {
        playerCam = Camera.main;
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!DialogueManager.instance.isInConversation)
            {
                Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    player.MoveToPoint(hit.point); // Move the player to the point they clicked.   
                    RemoveFocus(); // Remove the focus.
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Interactable interactableObjHit = hit.collider.GetComponent<Interactable>();
                if (interactableObjHit != null)
                {
                    SetFocus(interactableObjHit);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            player.FollowTarget(focus);
        }
        
        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        player.StopTargetFollow();
    }
}
