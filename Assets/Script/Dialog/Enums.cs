namespace Assets.Script.Dialog
{
    public enum DialogAction
    {
        None = 0,
        End = -1,       // Encerrar diálogo
        Repeat = -2,    // Repetir última ação (use somente para opções para evitar looping infinito)
    }
}
