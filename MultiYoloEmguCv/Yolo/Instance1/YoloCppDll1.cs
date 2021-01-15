using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo.Instance1
{
    internal class YoloCppDll1 : YoloCppDll,IYolo
    {
        public YoloCppDll1(string cfgFile, string weightFile, int gpuId)
        {
            YoloCppDllWrapper1.Init(cfgFile, weightFile, gpuId);
        }
        public void Dispose()
        {
            YoloCppDllWrapper1.Close();
        }
        public List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            var container = new BboxContainer();
            var elements = YoloCppDllWrapper1.Detect(mat.DataPointer, mat.Rows * mat.Cols, ref container);
            return GetResults(elements, container);
        }
        
    }
}
