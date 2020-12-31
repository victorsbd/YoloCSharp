using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo.Instance2
{
    internal class Yolo2 : Yolo,IYolo
    {
        public Yolo2(string cfgFile, string weightFile, int gpuId)
        {
            Wrapper2.Init(cfgFile, weightFile, gpuId);
        }
        public unsafe List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            Wrapper2.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out var elems, out var elemsSize);
            return GetResults(elems,elemsSize);
        }
        public void Dispose()
        {
            Wrapper2.Close();
        }
    }
}
