using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUI : MonoBehaviour
{
    [HideInInspector] public TextMeshPro text;
    [HideInInspector] public Animator anim;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        anim.SetBool("State", true);
    }

    void OnDisable()
    {
        anim.SetBool("State", false);
    }
}
