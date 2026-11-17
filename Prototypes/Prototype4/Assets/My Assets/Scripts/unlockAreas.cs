using UnityEngine;

public class unlockAreas : MonoBehaviour
{
    // 0 = nothing crossed, 1 = arch 1 done, 2 = arch 2 done, 3 = puzzle complete
    private int progress = 0;

    public GameObject stairs;
    public GameObject pitBarrier;
    public GameObject stairGems;
    public Material gemMaterial;

    public GameObject arch1Gem;
    public GameObject arch2Gem;
    public GameObject arch3Gem;

    public GameObject towerGem;

    public GameObject arch2Path;
    public GameObject arch3Path;
    public GameObject pitGems;

    [Header("Arch Sounds")]
    public ArchSound arch1Sound;
    public ArchSound arch2Sound;
    public ArchSound arch3Sound;

    [Header("Wrong Order Sound")]
    public AudioSource audioSource;
    public AudioClip wrongSound;

    void Start()
    {
        stairs.SetActive(false);
        pitBarrier.SetActive(true);

        ResetPuzzle();

        towerGem.SetActive(false);
        pitGems.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arch1"))
        {
            HandleArch(1, arch1Sound);
        }
        else if (other.CompareTag("Arch2"))
        {
            HandleArch(2, arch2Sound);
        }
        else if (other.CompareTag("Arch3"))
        {
            HandleArch(3, arch3Sound);
        }
        else if (other.CompareTag("Tower"))
        {
            towerGem.SetActive(true);
            pitGems.SetActive(true);
            unlockPit();
        }
    }

    void HandleArch(int archNumber, ArchSound archSound)
    {
        if (archNumber == progress + 1)
        {
            archSound.PlaySound();
            progress = archNumber;
            Debug.Log(archNumber + " crossed");

            switch (archNumber)
            {
                case 1:
                    arch1Gem.SetActive(true);
                    arch2Path.SetActive(true);
                    break;
                case 2:
                    arch2Gem.SetActive(true);
                    arch3Path.SetActive(true);
                    break;
                case 3:
                    arch3Gem.SetActive(true);
                    unlockStairs();
                    break;
            }
        }
        else if (archNumber <= progress)
        {
            archSound.PlaySound();
        }
        else
        {
            Debug.Log("Wrong order, puzzle resets");
            PlayWrongSound();
            ResetPuzzle();
        }
    }

    void ResetPuzzle()
    {
        progress = 0;

        arch1Gem.SetActive(false);
        arch2Gem.SetActive(false);
        arch3Gem.SetActive(false);

        arch2Path.SetActive(false);
        arch3Path.SetActive(false);
    }

    void PlayWrongSound()
    {
        if (audioSource != null && wrongSound != null)
        {
            audioSource.PlayOneShot(wrongSound);
        }
    }

    void unlockStairs()
    {
        stairs.SetActive(true);
    }

    void unlockPit()
    {
        pitBarrier.SetActive(false);
        foreach (Renderer r in stairGems.GetComponentsInChildren<Renderer>(true))
        {
            r.material = gemMaterial;
        }
    }
}