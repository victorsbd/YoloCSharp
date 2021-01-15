using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo.Instance3
{
    internal class YoloCppDll3 : YoloCppDll,IYolo
    {
        public YoloCppDll3(string cfgFile, string weightFile, int gpuId)
        {
            YoloCppDllWrapper3.Init(cfgFile, weightFile, gpuId);
        }
        public void Dispose()
        {
            YoloCppDllWrapper3.Close();
        }
        public List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            var container = new BboxContainer();
            var elements = YoloCppDllWrapper3.Detect(mat.DataPointer, mat.Rows * mat.Cols, ref container);
            return GetResults(elements, container);
        }
        
    }
}
