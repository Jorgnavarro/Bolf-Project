using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class DetectorColisionesBola : MonoBehaviour
{
    
    [SerializeField] Rigidbody bolaRb;
    [SerializeField] ParticleSystem golpesSuperficies, targetFireWorks;
    
    // Start is called before the first frame update
    void Start()
    {
        bolaRb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Suelo") || other.gameObject.CompareTag("WinZone1") || other.gameObject.CompareTag("WinZone2"))
        {
            SoundManager.Instance.soundManagerVFX.PlayOneShot(SoundManager.Instance.sonidosGolpes[0]);
            Instantiate(golpesSuperficies, transform.position, transform.rotation);
        }
        if(other.gameObject.CompareTag("Ping"))
        {
            SoundManager.Instance.soundManagerVFX.PlayOneShot(SoundManager.Instance.sonidosGolpes[2]);
            Instantiate(golpesSuperficies, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Target"))
        {
            SoundManager.Instance.soundManagerVFX.PlayOneShot(SoundManager.Instance.sonidosGolpes[5]);
            Instantiate(targetFireWorks, transform.position, transform.rotation);
        }    
    }

}
