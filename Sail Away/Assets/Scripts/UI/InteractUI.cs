﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUI : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI text;
    [HideInInspector] public Animator anim;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        transform.LookAt(GameManager.instance.cam.transform);
    }

    void OnEnable()
    {
        anim.SetBool("State", true);
    }
}
