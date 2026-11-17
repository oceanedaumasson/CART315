using System.Collections;
using UnityEngine;

public class PitSounds : MonoBehaviour
{
    public GameObject throbSound;
    public GameObject groanSound;
    public GameObject rumbleSound;

    [Header("Throb volume")]
    public float startVolume = 0.2f;
    public float addPerSecond = 0.005f;

    [Header("Throb pitch (also speeds it up)")]
    public float minPitch = 0.8f;
    public float maxPitch = 1.5f;
    public float pitchRampDuration = 90f;

    [Header("Rumble")]
    public float rumbleMaxVolume = 0.8f;
    public float rumbleRampDuration = 120f;

    [Header("Groan escalation")]
    public float rampDuration = 180f;
    public float firstGroanDelay = 25f;
    public Vector2 startGap = new Vector2(40f, 50f);
    public Vector2 endGap = new Vector2(6f, 10f);

    [Header("When the beast is fed")]
    [Tooltip("Volume lost per second. Higher = faster fade. Use 100 for an instant cut.")]
    public float fadeOutSpeed = 0.5f;
    [Tooltip("Seconds of calm after the fade, before the escalation starts over.")]

    [SerializeField] private pitSoundTrigger PitSoundTrigger;

    private AudioSource throbSource;
    private AudioSource groanSource;
    private AudioSource rumbleSource;
    private Coroutine groanRoutine;
    private float volume;
    private float elapsed;
    private bool escalating = true;

    void Start()
    {
        throbSource = throbSound.GetComponent<AudioSource>();
        groanSource = groanSound.GetComponent<AudioSource>();
        rumbleSource = rumbleSound.GetComponent<AudioSource>();

        rumbleSource.loop = true;
        rumbleSource.Play();

        BeginEscalation();
    }

    void Update()
    {
        if (!escalating) return;

        if (PitSoundTrigger.beastFed)
        {
            StartCoroutine(FedRoutine());
            return;
        }

        elapsed += Time.deltaTime;

        volume = Mathf.Min(1f, volume + addPerSecond * Time.deltaTime);
        throbSource.volume = volume;

        float pitchIntensity = Mathf.Clamp01(elapsed / pitchRampDuration);
        throbSource.pitch = Mathf.Lerp(minPitch, maxPitch, pitchIntensity * pitchIntensity);

        float rumbleIntensity = Mathf.Clamp01(elapsed / rumbleRampDuration);
        rumbleSource.volume = Mathf.Lerp(0f, rumbleMaxVolume, rumbleIntensity * rumbleIntensity);
    }

    void BeginEscalation()
    {
        elapsed = 0f;
        volume = startVolume;
        throbSource.volume = startVolume;
        throbSource.pitch = minPitch;
        rumbleSource.volume = 0f;

        escalating = true;
        groanRoutine = StartCoroutine(GroanRoutine());
    }

    IEnumerator FedRoutine()
    {
        escalating = false;
        PitSoundTrigger.beastFed = false;

        if (groanRoutine != null) StopCoroutine(groanRoutine);

        // Fade out sounds
        while (throbSource.volume > 0f || rumbleSource.volume > 0f)
        {
            float step = fadeOutSpeed * Time.deltaTime;
            throbSource.volume = Mathf.MoveTowards(throbSource.volume, 0f, step);
            rumbleSource.volume = Mathf.MoveTowards(rumbleSource.volume, 0f, step);
            yield return null;
        }
        
        PitSoundTrigger.beastFed = false;
        BeginEscalation();
    }

    IEnumerator GroanRoutine()
    {
        yield return new WaitForSeconds(firstGroanDelay);

        while (true)
        {
            groanSource.Play();

            float intensity = Mathf.Clamp01(elapsed / rampDuration);
            float min = Mathf.Lerp(startGap.x, endGap.x, intensity);
            float max = Mathf.Lerp(startGap.y, endGap.y, intensity);

            yield return new WaitForSeconds(Random.Range(min, max));
        }
    }
}