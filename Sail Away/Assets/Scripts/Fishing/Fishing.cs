using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Fishing : MonoBehaviour
{
    public readonly string player = "Player";
    public readonly string interactText;

    InteractUI interactUI;

    bool canInteract = false;
    bool isInteracting = false;

    public UnityEvent interactEvent;

    void Start()
    {
        interactUI = GameManager.instance.interactUI;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            interactEvent.Invoke();

            canInteract = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player))
        {
            Vector3 popUpPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            interactUI.transform.position = popUpPosition;
            interactUI.text.text = interactText;
            interactUI.gameObject.SetActive(true);

            canInteract = true;
        }
    }

    IEnumerator OnTriggerExit(Collider other)
    {
        if (other.CompareTag(player))
        {
            canInteract = false;

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.xp += 5;

            interactUI.anim.SetBool("State", false);

            yield return new WaitForSeconds(0.5f);

            interactUI.gameObject.SetActive(false);
        }
    }
}
