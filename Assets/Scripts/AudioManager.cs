using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 

    [HideInInspector] public AudioSource musicaMenu;
    [HideInInspector] public AudioSource musicaJogo;
    private AudioSource sfxSource;

    [Header("Efeitos Sonoros (SFX)")]
    public AudioClip somMoeda;
    public AudioClip somSalto;
    public AudioClip somMorte;
    public AudioClip somEstrela;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            AudioSource[] fontesDeAudio = GetComponents<AudioSource>();
            if (fontesDeAudio.Length >= 2)
            {
                musicaMenu = fontesDeAudio[0]; 
                musicaJogo = fontesDeAudio[1]; 
            }

            sfxSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip, 0.2f);
        }
    }

    public void MudarParaMusicaJogo()
    {
        // Para tudo primeiro para limpar o buffer
        if (musicaMenu != null) musicaMenu.Stop();
        
        if (musicaJogo != null && !musicaJogo.isPlaying) 
        {
            musicaJogo.time = 0f;
            musicaJogo.Play();
        }
    }

    public void MudarParaMusicaMenu()
    {
        if (musicaJogo != null) musicaJogo.Stop();
        
        if (musicaMenu != null && !musicaMenu.isPlaying) 
        {
            musicaMenu.time = 0f;
            musicaMenu.Play();
        }
    }
}