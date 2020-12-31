using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo.Instance3
{
    internal class Yolo3 : Yolo,IYolo
    {
        public Yolo3(string cfgFile, string weightFile, int gpuId)
        {
            Wrapper3.Init(cfgFile, weightFile, gpuId);
        }
        public unsafe List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            Wrapper3.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out var elems, out var elemsSize);
            return GetResults(elems,elemsSize);
        }
        public void Dispose()
        {
            Wrapper3.Close();
        }
    }
}
