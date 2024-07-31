using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class DetectorColisionesBola : MonoBehaviour
{
    
    [SerializeField] Rigidbody bolaRb;
    [SerializeField] ParticleSystem polvoParticula;
    // Start is called before the first frame update
    void Start()
    {
        bolaRb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Suelo"))
        {
            SoundManager.Instance.soundManagerVFX.PlayOneShot(SoundManager.Instance.sonidosGolpes[0]);
        }    
    }

    private void OnMouseDown() 
    {    
        SoundManager.Instance.soundManagerVFX.PlayOneShot(SoundManager.Instance.sonidosGolpes[1]);
        bolaRb.AddForce(Vector3.forward*30, ForceMode.Impulse);
        Instantiate(polvoParticula, transform.position, transform.rotation);
    }
}
