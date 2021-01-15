using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo.Instance0
{
    internal class YoloCppDll0 : YoloCppDll,IYolo
    {
        public YoloCppDll0(string cfgFile, string weightFile, int gpuId)
        {
            YoloCppDllWrapper0.Init(cfgFile, weightFile, gpuId);
        }
        public void Dispose()
        {
            YoloCppDllWrapper0.Close();
        }
        public List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            var container = new BboxContainer();
            var elements = YoloCppDllWrapper0.Detect(mat.DataPointer, mat.Rows * mat.Cols, ref container);
            return GetResults(elements, container);
        }
        
    }
}
