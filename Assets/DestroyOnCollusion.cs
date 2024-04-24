using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public AudioClip destructionSoundClip; // Audio clip to play when destroyed
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Make sure audioSource is not null
        if (audioSource == null)
        {
            // Add an AudioSource component if it doesn't exist
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the destruction sound clip to the AudioSource component
        audioSource.clip = destructionSoundClip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Wall" tag
        if (collision.collider.CompareTag("Wall"))
        {
            // Play the destruction sound clip
            if (audioSource != null && destructionSoundClip != null)
            {
                audioSource.Play();
            }

            // Destroy the collided object
            Destroy(collision.gameObject);
        }
    }
}
