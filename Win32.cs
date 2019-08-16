using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RGSSBitmapTextGenerator
{
    class Win32
    {
        public const string MailSlotNameEditor = "\\\\.\\mailslot\\editor";
        public const string MailSlotNamePreview = "\\\\.\\mailslot\\preview";

        public const int MAILSLOT_WAIT_FOREVER = -1;
        public const int INVALID_HANDLE_VALUE = -1;
        public const int GENERIC_WRITE = 0x40000000;
        public const int FILE_SHARE_READ = 0x1;
        public const int OPEN_EXISTING = 3;
        public const int FILE_ATTRIBUTE_NORMAL = 0x80;

        [DllImport("kernel32")]
        public static extern void CloseHandle(IntPtr hObject);

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateMailslot(
            string lpName,
            uint nMaxMessageSize,
            int lReadTimeout,
            IntPtr lpSecurityAttributes);

        [DllImport("kernel32")]
        public static extern bool GetMailslotInfo(
            IntPtr hMailslot,
            IntPtr lpMaxMessageSize,
            out uint lpNextSize,
            IntPtr lpMessageCount,
            IntPtr lpReadTimeout);

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr ReadFile(
            IntPtr hFile,
            [Out] byte[] lpBuffer,
            uint nNumberOfBytesToRead,
            out uint lpNumberOfBytesRead,
            IntPtr lpOverlapped);

        [DllImport("kernel32")]
        public static extern IntPtr WriteFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            IntPtr lpOverlapped);

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);
    }
}
