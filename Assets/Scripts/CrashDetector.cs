using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeDelay = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            FindObjectOfType<PlayerController>().DisableControl();
            GetComponent<AudioSource>().PlayOneShot(crashSound, 1f);
            crashEffect.Play();
            Invoke("ReloadScene", invokeDelay);
            hasCrashed = true;
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
