using System.Runtime.InteropServices;

Console.WriteLine("Testing native library loading with dependency resolution...");

var ext = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".dll" :
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? ".dylib" : ".so";

var assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
var assemblyDirectory = Path.GetDirectoryName(assemblyLocation) ?? throw new InvalidOperationException("Could not determine assembly directory.");
var libName = args.Length > 0 && args[0] == "load" ? "NativeLibrary" : "NativeLibraryWithoutDeps";
var libPath = Path.Combine(assemblyDirectory, libName + ext);

Console.WriteLine($"Library path: {libPath}");
Console.WriteLine($"Library exists: {File.Exists(libPath)}");

if (File.Exists(libPath))
{
    try
    {
        Console.WriteLine("Attempting to load library...");
        var handle = NativeLibrary.Load(libPath);
        Console.WriteLine($"Library loaded successfully: {handle}");

        Console.WriteLine("Attempting to get Run export...");
        var runPtr = NativeLibrary.GetExport(handle, "Run");
        Console.WriteLine($"Run export found: {runPtr}");

        // Test calling the function
        Console.WriteLine("Calling Run(1)...");
        var runDelegate = Marshal.GetDelegateForFunctionPointer<RunDelegate>(runPtr);
        var result = runDelegate(1);
        Console.WriteLine($"Function result: {result}");

        NativeLibrary.Free(handle);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine($"Stack trace: {ex.StackTrace}");
    }
}

delegate int RunDelegate(int a);
