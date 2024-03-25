using UnityEngine;
using UnityEngine.Audio;
public class voice_die : MonoBehaviour
{
    public voice_contorl voiceoverController;


    private void PlayerDied()
    {
        voiceoverController.StopVoiceover();
    }
    void Start()
    {
        PlayerDied();
    }

    public void StartButtonPressed()
    {
        voiceoverController.PlayVoiceover();
    }
}