using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseItemDialog : MonoBehaviour, IUseItem
{
    [Header("Lista de Itens Aceitos")]
    public List<ItemGroup> items;
    [Header("Textos para cada item")]
    public List<TextGroup> texts;
    [Header("Tipo de cada texto")]
    public List<TextInteractionType> types;

    [Header("Walk before use")]
    public bool shouldWalk = false;
    [ConditionalHide("shouldWalk")] public Vector3 CustomWalkOffset = Vector3.zero;
    [ConditionalHide("shouldWalk")] public Transform lookAtObj;
    private Dialog dialog;

    void Awake()
    {
        dialog = gameObject.AddComponent<Dialog>();
    }

    public bool UseItem(GameObject item)
    {
        int index = -1;
        for (int i = 0; i < items.Count; i++)
        {
            InventoryObject invobj = InventoryManager.Instance.objects.FirstOrDefault(o => o.group == items[i]);
            if (invobj == null)
                continue;

            if (item.name == invobj.mousePrefab.name + "(Clone)")
            {
                index = i;
                break;
            }
        }

        if (index < 0)
            return false;

        dialog.Configure(texts[index], types[index]);

        StartCoroutine(Execute(item));

        return true;
    }

    IEnumerator Execute(GameObject item)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), null));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;
        }
        yield return null;

        DialogAction result = DialogAction.None;
        yield return StartCoroutine(dialog.Execute(item, (value) => result = value));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

        if (result == DialogAction.RemoveDialog)
            Destroy(this);
    }
}
