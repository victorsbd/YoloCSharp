using System;
using System.Collections.Generic;
using Emgu.CV;

namespace MultiYoloEmguCv.Yolo
{
    internal interface IYolo: IDisposable
    {
        List<YoloResult> Detect(Mat mat, float thresh = 0.2f);
    }
}
