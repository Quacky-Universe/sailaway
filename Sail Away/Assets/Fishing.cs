using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Fishing : MonoBehaviour
{
    public readonly string player = "Player";
    public readonly string interactText;

    InteractUI interactUI;

    public Event interactEvent;

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player))
        {
            if (interactUI != null)
            {
                interactUI.anim.SetBool("State", false);
                yield return new WaitForSeconds(0.5f);
                interactUI.anim.SetBool("State", true);
            }

            Vector3 popUpPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

            interactUI = ObjectPooler.instance.SpawnFromPool("Interact UI", popUpPosition, Quaternion.identity).GetComponent<InteractUI>();
            interactUI.text.text = interactText;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(player))
        {
            if (interactUI != null && interactUI.enabled)
            {
                interactUI.gameObject.SetActive(false);
            }
        }
    }
}
