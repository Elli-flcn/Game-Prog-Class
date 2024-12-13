using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] AudioClip openingDoorSFX;
    [SerializeField] AudioClip closingDoorSFX; // You can add a new audio clip for closing sound

    // Start is called before the first frame update
    void Start()
    {
        // Trigger the "Open" animation
        GetComponent<Animator>().SetTrigger("Open");

        // Optionally play the sound effect when the door opens
        PlayOpeningDoorSFX();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Plays the door opening sound effect
    void PlayOpeningDoorSFX()
    {
        if (openingDoorSFX != null) // Check if the sound clip is assigned
        {
            AudioSource.PlayClipAtPoint(openingDoorSFX, Camera.main.transform.position);
        }
    }

    // Plays the door closing sound effect
    void PlayClosingDoorSFX()
    {
        if (closingDoorSFX != null) // Check if the closing sound clip is assigned
        {
            AudioSource.PlayClipAtPoint(closingDoorSFX, Camera.main.transform.position);
        }
    }
}
