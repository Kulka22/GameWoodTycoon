using UnityEngine;

public enum SoundType
{
    TREEFELL,
    HARVESTER,
    POOL,
    DEBARKING,
    SAWING,
    PEELLING,
    DRYING,
    GLUE,
    PRESSING,
    PURCHASE,
    FAIL
}

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] Sounds;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {

    }

    public static void PlaySound(SoundType sound, float volume = 0.5f)
    {
        //Debug.Log("Sound manager is ACTIVE");
        instance.audioSource.PlayOneShot(instance.Sounds[(int)sound], volume);
    }
}
