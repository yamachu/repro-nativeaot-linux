namespace NativeLibrary;

using System;
using System.Runtime.InteropServices;

public static class Class1
{
    [DllImport("NativeLibraryDependency", EntryPoint = "Sum42")]
    public static extern int Sum42(int a);

    [UnmanagedCallersOnly(EntryPoint = "Run")]
    public static int Run(int a)
    {
        return Sum42(a);
    }

    [UnmanagedCallersOnly(EntryPoint = "NoDepRun")]
    public static int NoDepRun(int a)
    {
        return 42 + a;
    }
}
