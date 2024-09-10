using Assets.Script;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using UnityEngine;

public class HankSpecial : MonoBehaviour, ISpecial
{
    public PlayerData playerData;
    public AudioSource audioSource;
    public AudioClip pickup;

    [Header("Item")]
    public ItemGroup itemGroup = ItemGroup.Default;
    [SerializeField] private AudioClip pickupAudio;

    private int step = 0;

    public void Special(GameObject who)
    {
        switch (step)
        {
            case 0:
                audioSource.loop = true;
                audioSource.Play();
                break;

            case 1:
            case 2:
                audioSource.loop = false;
                audioSource.Stop();
                audioSource.PlayOneShot(pickup);
                break;

            case 3:
                InventoryManager.Instance.PickUpAudio(pickupAudio);
                if (playerData.AddItem(itemGroup))
                    InventoryManager.Instance.Open(itemGroup, true);

                playerData.AddStep(GameSteps.GetFirstMission);

                break;
        }

        step++;
        if (step > 3)
            step = 0;
    }
}
