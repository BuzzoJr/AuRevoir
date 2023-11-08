namespace Assets.Script.Dialog
{
    public enum DialogAction
    {
        None = 0,
        End,       // Encerrar diálogo
        Repeat,    // Repetir última ação (use somente para opções para evitar looping infinito)
        Special,        // Usar uma ação especial no objeto de origem
        RemoveDialog,   // Encerra e remove o dialogo
    }
}
