using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoSaltar;// this saves the jump sound
    //public AudioClip sonidoRecibirDanio;//
    //public AudioClip sonidoAtacar;//
    public AudioClip sonidoCaida;// this saves the fall sound
    //public AudioClip sonidoMuerte;//
    public AudioClip sonidoMov1;// this saves the step1 sound
    public AudioClip sonidoMov2;// this saves the step2 sound
    
    public void playSaltar()
    {
        audioSource.PlayOneShot(sonidoSaltar); // this plays the saved jump sound
    }

    public void playCaida()
    {
        audioSource.PlayOneShot(sonidoCaida); // this plays the saved fall sound
    }

    public void playMov1()
    {
        audioSource.PlayOneShot(sonidoMov1); // this plays the saved step1 sound
    }

    public void playMov2()
    {
        audioSource.PlayOneShot(sonidoMov2); // this plays the saved step2 sound
    }

 
}
