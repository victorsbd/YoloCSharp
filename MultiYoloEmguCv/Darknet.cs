using System;
using System.Collections.Generic;
using Emgu.CV;
using MultiYoloEmguCv.YoloWrapper;

namespace MultiYoloEmguCv
{
    /// <inheritdoc />
    /// <summary>
    /// Provides a Darknet detector which can be used to analyze image and find all detectable objects inside
    /// </summary>
    public class Darknet : IDisposable
    {
        private readonly Yolo _yolo;

        /// <summary>
        /// Initializes a new Darknet detector with the <paramref name="cfgFile"/> and the <paramref name="weightFile"/>
        /// </summary>
        /// <param name="cfgFile">The *.cfg file</param>
        /// <param name="weightFile">The *.weights file</param>
        /// <param name="instanceNumber">The instance of YoloApi.dll to avoid static detector limitation from darknet c++ library. A file with the name YoloApi{instancenumber}.dll is needed</param>
        /// <param name="gpuId">The index of a CUDA compatible GPU</param>
        /// <param name="cudaVersion">Cuda version, 10 or 11, by default 10</param>
        public Darknet(string cfgFile, string weightFile, int instanceNumber, int gpuId, int cudaVersion)
        {
            if (instanceNumber > 3 || instanceNumber < 0)
            {
                throw new ArgumentException("instanceNumber must be  0 <= and <= 3");
            }
            _yolo = new Yolo(cfgFile, weightFile, gpuId, instanceNumber,cudaVersion);
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
