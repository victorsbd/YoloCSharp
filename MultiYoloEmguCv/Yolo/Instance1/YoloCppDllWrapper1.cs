using System;
using System.Runtime.InteropServices;

namespace MultiYoloEmguCv.Yolo.Instance1
{
    internal static class YoloCppDllWrapper1
    {
        private const string YoloLibraryName = "yolo_cpp_dll1.dll";
        [DllImport(YoloLibraryName, EntryPoint = "init")]
        internal static extern int Init(string cfgFile, string weightFile, int gpuId = 0);

        [DllImport(YoloLibraryName, EntryPoint = "detect_image")]
        internal static extern int Detect(string filename, ref BboxContainer container);

        [DllImport(YoloLibraryName, EntryPoint = "detect_mat")]
        internal static extern int Detect(IntPtr pArray, int nSize, ref BboxContainer container);

        [DllImport(YoloLibraryName, EntryPoint = "dispose")]
        internal static extern int Close();
    }
}
