using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo.Instance1
{
    internal class Yolo1 : Yolo,IYolo
    {
        public Yolo1(string cfgFile, string weightFile, int gpuId)
        {
            Wrapper1.Init(cfgFile, weightFile, gpuId);
        }
        public unsafe List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            Wrapper1.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out var elems, out var elemsSize);
            return GetResults(elems,elemsSize);
        }
        public void Dispose()
        {
            Wrapper1.Close();
        }
    }
}
