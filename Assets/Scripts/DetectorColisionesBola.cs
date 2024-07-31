using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class DetectorColisionesBola : MonoBehaviour
{
    
    [SerializeField] Rigidbody bolaRb;
    [SerializeField] ParticleSystem golpesSuperficies;
    
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
            Instantiate(golpesSuperficies, transform.position, transform.rotation);
        }    
    }

}
