using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Script.Dialog
{
    public class Dialog : MonoBehaviour
    {
        public GameObject DialogBox { get; set; }
        public TMP_Text DialogText { get; set; }
        public TextGroup TextGroup { get; set; }

        public IEnumerator Execute()
        {
            DialogBox.SetActive(true);
            yield return StartCoroutine(Execute(AllDialogs.Sequence[TextGroup], (value) => { }));
            DialogBox.SetActive(false);
        }

        public IEnumerator Execute(List<object> seq, System.Action<DialogAction> callback)
        {
            DialogAction result = DialogAction.None;

            int pos = 0;
            while (pos < seq.Count)
            {
                if (seq[pos] is DialogAction action)
                {
                    result = action;
                    break;
                }

                if (seq[pos] is int i)
                {
                    TextData data = Locale.Locale.Texts[TextGroup][i];
                    DialogText.color = TextColorManager.textTypeColors[data.Type];
                    DialogText.text = data.Type != TextType.Player ? data.Type + ": " + data.Text : data.Text;

                    if (data.Delay >= 0)
                        yield return new WaitForSeconds(data.Delay > 0 ? data.Delay : 1.5f);
                    else
                        yield return new WaitForSeconds(1f); // TODO: Trocar para esperar por um click

                    pos += 1;
                    continue;
                }

                // Dict = Opções de interação de diálogo
                if (seq[pos] is Dictionary<int, List<object>> options)
                {
                    foreach (int key in options.Keys)
                    {
                        // TODO: Mostrar cada opção como clicável
                        TextData data = Locale.Locale.Texts[TextGroup][key];
                        DialogText.color = TextColorManager.textTypeColors[data.Type];
                        DialogText.text = data.Type != TextType.Player ? data.Type + ": " + data.Text : data.Text;

                    }

                    yield return new WaitForSeconds(1f); // TODO: Esperar a escolha da opção
                    int selected = options.Keys.First(); // Colocar a opção selecionada

                    yield return StartCoroutine(Execute(options[selected], (value) => result = value));

                    // Ações de controle
                    if (result == DialogAction.End)
                        break;

                    if (result != DialogAction.Repeat)
                        pos += 1;

                    result = DialogAction.None;
                    continue;
                }
            }

            callback(result);
        }
    }
}
