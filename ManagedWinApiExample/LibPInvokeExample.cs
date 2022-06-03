using PInvoke;

namespace ManagedWinApiExample;

public static class LibPInvokeExample
{
    public static void RunMessageBox()
    {
        var options = User32.MessageBoxOptions.MB_YESNO;
        var result = User32.MessageBox(IntPtr.Zero, "Текст", "Заголов", options);
        if (result == User32.MessageBoxResult.IDYES)
        {
            Console.WriteLine("Вы выбрали Да");
        }
    }
    
    public static void RunEnumWindows()
    {
        User32.EnumWindows(LpEnumFunc, IntPtr.Zero);

        static bool LpEnumFunc(IntPtr hWnd, IntPtr lParam)
        {
            var text = User32.GetWindowText(hWnd);
            Console.WriteLine(text);
            return true;
        }
    }
}