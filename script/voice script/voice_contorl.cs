using UnityEngine;
using UnityEngine.Audio;

public class voice_contorl : MonoBehaviour
{
   
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayVoiceover()
    {
        audioSource.Play();
    }

    public void StopVoiceover()
    {
        audioSource.Stop();
    }
       public void PauseVoiceover()
    {
        audioSource.Pause();
    }
       public void UnpauseVoiceover()
    {
        audioSource.UnPause();
    }
}
