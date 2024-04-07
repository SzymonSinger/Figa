using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    private AudioSource audioSource;
    private ParticleSystem particleSystem;
    private BeatCounter counter;
    public GameObject ToDestroy;

    private void Awake()
    {
        counter = FindObjectOfType<BeatCounter>();
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponentInChildren<ParticleSystem>(); // Assuming the ParticleSystem is a child of the enemy object
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        // Play the particle effect
        if (particleSystem != null)
        {
            particleSystem.Play();
        }

        // Play the explosion sound
        if (audioSource != null)
        {
            audioSource.Play();
        }
        counter.RemoveHealth();
        Destroy(ToDestroy);
    }
}