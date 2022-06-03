using System.Diagnostics.CodeAnalysis;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace ManagedWinApiExample;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class LibCsWin32Example
{
    public static void RunMessageBox()
    {
        var type = MESSAGEBOX_STYLE.MB_YESNO;
        var result = Windows.Win32.PInvoke.MessageBox(new HWND(0), "Текст", "Заголов", type);

        if (result == MESSAGEBOX_RESULT.IDYES)
        {
            Console.WriteLine("Вы выбрали Да");
        }
    }

    public static void RunEnumWindowsUnsafe()
    {
        Windows.Win32.PInvoke.EnumWindows(LpEnumFunc, new LPARAM());
        
        static BOOL LpEnumFunc(HWND hwnd, LPARAM lparam)
        {
            unsafe
            {
                var value = stackalloc char[64];
                var lpString = new PWSTR(value);
                Windows.Win32.PInvoke.GetWindowText(hwnd, lpString, 64);
                Console.WriteLine(lpString.ToString());
                return new BOOL(true);
            }
        }
    }
}