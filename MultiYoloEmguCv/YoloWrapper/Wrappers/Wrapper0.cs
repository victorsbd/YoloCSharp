using System;
using System.Runtime.InteropServices;

namespace MultiYoloEmguCv.YoloWrapper.Wrappers
{
    internal static class Wrapper0
    {
        private const string DllName = "YoloApi0";

        [DllImport(DllName, EntryPoint = "initDetector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Init(string cfgFile, string weightFile, int gpuId = 0);
        [DllImport(DllName, EntryPoint = "closeDetector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Close();
        [DllImport(DllName, EntryPoint = "detect", CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe void Detect(IntPtr matPtr, int matRows, int matCols, float thresh, bool useMean, out BoundingBox10* elems, out int elemsSize);
        [DllImport(DllName, EntryPoint = "detect", CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe void Detect(IntPtr matPtr, int matRows, int matCols, float thresh, bool useMean, out BoundingBox11* elems, out int elemsSize);

    }
}