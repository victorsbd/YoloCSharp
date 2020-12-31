using System;
using System.Collections.Generic;
using Emgu.CV;
using MultiYoloEmguCv.Yolo;
using MultiYoloEmguCv.Yolo.Instance0;
using MultiYoloEmguCv.Yolo.Instance1;
using MultiYoloEmguCv.Yolo.Instance2;
using MultiYoloEmguCv.Yolo.Instance3;

namespace MultiYoloEmguCv
{
    /// <inheritdoc />
    /// <summary>
    /// Provides a Darknet detector which can be used to analyze image and find all detectable objects inside
    /// </summary>
    public class Darknet : IDisposable
    {
        private readonly IYolo _yolo;

        /// <summary>
        /// Initializes a new Darknet detector with the <paramref name="cfgFile"/> and the <paramref name="weightFile"/>
        /// </summary>
        /// <param name="cfgFile">The *.cfg file</param>
        /// <param name="weightFile">The *.weights file</param>
        /// <param name="instanceNumber">The instance of YoloApi.dll to avoid static detector limitation from darknet c++ library. A file with the name YoloApi{instancenumber}.dll is needed</param>
        /// <param name="gpuId">The index of a CUDA compatible GPU</param>
        public Darknet(string cfgFile, string weightFile, DarknetInstance instanceNumber, int gpuId)
        {
            switch (instanceNumber)
            {
                case DarknetInstance.Instance0:
                    _yolo = new Yolo0(cfgFile,weightFile,gpuId);
                    break;
                case DarknetInstance.Instance1:
                    _yolo = new Yolo1(cfgFile, weightFile, gpuId);
                    break;
                case DarknetInstance.Instance2:
                    _yolo = new Yolo2(cfgFile, weightFile, gpuId);
                    break;
                case DarknetInstance.Instance3:
                    _yolo = new Yolo3(cfgFile, weightFile, gpuId);
                    break;
            }
        }

        /// <summary>
        /// Use to detect objects on an OpenCV Mat object and return all found objects
        /// </summary>
        /// <returns>List of <see cref="YoloResult">YoloResult</see></returns>
        /// <param name="mat">The frame to analyze</param>
        /// <param name="thresh">Threshold at which an object should be confirmed</param>
        public List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            return _yolo.Detect(mat,thresh);
        }

        /// <inheritdoc />
        /// <summary>
        /// Dispose method to close the darknet process 
        /// </summary>
        public void Dispose()
        {
            _yolo.Dispose();
        }
    }
}
