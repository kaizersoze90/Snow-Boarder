using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float invokeDelay = 2f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip finishSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().PlayOneShot(finishSound, 1f);
            finishEffect.Play();
            Invoke("ReloadScene", invokeDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
