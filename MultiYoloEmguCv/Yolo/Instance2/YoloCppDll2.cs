using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo.Instance2
{
    internal class YoloCppDll2 : YoloCppDll,IYolo
    {
        public YoloCppDll2(string cfgFile, string weightFile, int gpuId)
        {
            YoloCppDllWrapper2.Init(cfgFile, weightFile, gpuId);
        }
        public void Dispose()
        {
            YoloCppDllWrapper2.Close();
        }
        public List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            var container = new BboxContainer();
            var elements = YoloCppDllWrapper2.Detect(mat.DataPointer, mat.Rows * mat.Cols, ref container);
            return GetResults(elements, container);
        }
        
    }
}
