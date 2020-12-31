using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo.Instance0
{
    internal class Yolo0 : Yolo,IYolo
    {
        public Yolo0(string cfgFile, string weightFile, int gpuId)
        {
            Wrapper0.Init(cfgFile, weightFile, gpuId);
        }
        public unsafe List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            Wrapper0.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out var elems, out var elemsSize);
            return GetResults(elems,elemsSize);
        }
        public void Dispose()
        {
            Wrapper0.Close();
        }
    }
}
