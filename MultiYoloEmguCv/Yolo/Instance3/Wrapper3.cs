using System;
using System.Runtime.InteropServices;

namespace MultiYoloEmguCv.Yolo.Instance3
{
    internal static class Wrapper3
    {
        private const string DllName = "YoloApi3";

        [DllImport(DllName, EntryPoint = "initDetector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Init(string cfgFile, string weightFile, int gpuId = 0);
        [DllImport(DllName, EntryPoint = "closeDetector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Close();
        [DllImport(DllName, EntryPoint = "detect", CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe void Detect(IntPtr matPtr, int matRows, int matCols, float thresh, bool useMean, out BoundingBox* elems, out int elemsSize);
    }
}