namespace NativeLibraryWithoutDeps;

using System;
using System.Runtime.InteropServices;

public static class Class1
{
    [UnmanagedCallersOnly(EntryPoint = "Run")]
    public static int Run(int a)
    {
        return 42 + a;
    }
}
