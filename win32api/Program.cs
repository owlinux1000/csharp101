// See https://aka.ms/new-console-template for more information

// [DllImport]するためにはこれが必要っぽい
using System.Runtime.InteropServices;
namespace Win32API;
class Program {

    // 使うDLLを指定する
    [DllImport("user32.dll")]
    // 関数定義をC#の文脈で行う
    static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

    static void Main(string[] args) {
        // nullはダメみたいで、IntPtr.Zeroでないといけないみたい
        MessageBox(IntPtr.Zero, "MessageBox called from C#", "", 0);
    }
}
