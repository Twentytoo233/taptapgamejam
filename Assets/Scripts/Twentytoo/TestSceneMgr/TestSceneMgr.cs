using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestSceneMgr : MonoBehaviour
{
    private void loadCompleteAction()
    {
        Debug.Log("≥°æ∞º”‘ÿÕÍ±œ");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {

            SceneMgr.Instance.LoadSceneAsyn("TwentytooTest2",loadCompleteAction);
        }
    }
}
