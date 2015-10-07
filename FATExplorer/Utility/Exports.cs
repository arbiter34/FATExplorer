﻿using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FATExplorer
{
    public static class Exports
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall,
        SetLastError = true)]
        public static extern SafeFileHandle CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr SecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer,
             uint nNumberOfBytesToRead, 
            out uint lpNumberOfBytesRead, 
            IntPtr lpOverlapped);

        public enum EMoveMethod : uint
        {
            Begin = 0,
            Current = 1,
            End = 2
        }

        [DllImport("kernel32.dll", EntryPoint = "SetFilePointer")]
        static extern uint SetFilePointer(
              [In] Microsoft.Win32.SafeHandles.SafeFileHandle hFile,
              [In] int lDistanceToMove,
              [In, Out] ref int lpDistanceToMoveHigh,
              [In] EMoveMethod dwMoveMethod);



        public const int FILE_FLAG_NO_BUFFERING = 0x20000000;

    }
}
