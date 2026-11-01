using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InteractionJoueur : MonoBehaviour
{
    [Header("Raycast d'interaction")]
    [SerializeField] float distanceInteraction = 2f; // Distance maximale pour interagir avec un interrupteur
    [SerializeField] LayerMask couchesInteractives; // Couches sur lesquelles le joueur peut


    [Header("Composants")]
    ControlesJoueur controles;
    Animator animator;

    void Start()
    {
        controles = GetComponent<ControlesJoueur>();
        animator = GetComponent<Animator>();
    }


    void OnDrawGizmos()
    {
        // Dessiner un rayon pour visualiser la distance d'interaction dans l'éditeur
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.forward * distanceInteraction);
    }

    void OnTriggerEnter(Collider fin)
    {
        if (fin.gameObject.tag == "fin" )

        {
            StartCoroutine(FinJeu());
        }
    }
    public IEnumerator FinJeu()
    {
        animator.SetTrigger("idle");
        controles.etatPerso = EtatPerso.FINJEU;
        yield return new WaitForSeconds(5);
        controles.RedemarrerlaPartie();
    }
    public void DetecterInterrupteur()
    {
        Vector3 origine = transform.position+Vector3.up;
        Vector3 direction = transform.forward;
        if (Physics.Raycast(origine, direction, out RaycastHit collision, distanceInteraction, couchesInteractives, QueryTriggerInteraction.Collide))
        {
            Interrupteur origineInterrupteur = collision.collider.GetComponent<Interrupteur>();
            //ya til piege recup interrupteir script la anim qui jopue
            //detect script interrupteur
            //delcner l'anim, activer sur la porte
            //creer carrer invisible entre porte pour trigger si result raycast vas a collion et creer et stock info dedas raycast detecter obj avec genre collider
            if (origineInterrupteur != null)
            {
                origineInterrupteur.Activer();
               
            }
            controles.Invoke("RetourEtatLibre", 3f);
            
        }


    }
}
