using UnityEngine;

public class CombatJoueur : MonoBehaviour
{


    [Header("Composants")]
    ControlesJoueur controles;
    Animator animator;
    AudioSource audioSource;

    [SerializeField] AudioClip sonAttaque;

    void Start()
    {
        controles = GetComponent<ControlesJoueur>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void Attaquer()
    {

    }
    public void SonAttaque()
    {
        audioSource.PlayOneShot(sonAttaque);
    }
}
