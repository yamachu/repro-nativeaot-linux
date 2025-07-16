## NativeAOT Segmentation Fault Reproduction on Linux with net8.0

This repository is created to reproduce a segmentation fault issue that occurs when generating a NativeLibrary using NativeAOT on Linux with `net8.0` as the target framework.

## Summary

- When building a NativeLibrary with NativeAOT targeting `net8.0` **on Linux**, a segmentation fault occurs at runtime.
- This issue **does not occur** on Windows or macOS.
- The issue is also **not reproducible** on Linux when targeting `net9.0`.

This repository provides a minimal setup to demonstrate and reproduce this problem. 

---

### TL;DR

- **Platform:** Linux only
- **TargetFramework:** net8.0 only
- **Problem:** Segmentation fault when running NativeAOT-generated NativeLibrary
- **Not affected:** Windows, macOS, or net9.0

## How to Reproduce

Run on Linux

1. dotnet publish --use-current-runtime -f net8.0
2. dotnet run --project Runner
3. Observe the segmentation fault
