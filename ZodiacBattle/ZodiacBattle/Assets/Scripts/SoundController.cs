using UnityEngine;


public class SoundController : MonoBehaviour
{
    public AudioClip hitting;

    private AudioSource audioSource;
    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            this.audioSource.PlayOneShot(this.hitting);
        }
    }
}
