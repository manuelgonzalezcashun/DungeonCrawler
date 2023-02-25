using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset _inkJSON;

    [SerializeField] private GameObject door;

    private bool playerInRange;

    void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }
    void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if(Input.GetButtonDown("Fire3"))
            {
                DialogueManager.GetInstance().EnterDialogueMode(_inkJSON);
                door.SetActive(true);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
