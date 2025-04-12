using System;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UI;

public class ShowMessage : MonoBehaviour
{
    public GameObject messagePanel;
    public string message;
    
    private Text _messageText;
    
    private void Start()
    {
        _messageText = messagePanel.GetComponentInChildren<Text>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _messageText.text = message;
        messagePanel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        messagePanel.SetActive(false);
    }

    
}