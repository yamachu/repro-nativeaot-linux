namespace NativeLibraryDependency;

using System;
using System.Runtime.InteropServices;

public static class Class1
{
    [UnmanagedCallersOnly(EntryPoint = "Sum42")]
    public static int Sum42(int a)
    {
        return 42 + a;
    }
}