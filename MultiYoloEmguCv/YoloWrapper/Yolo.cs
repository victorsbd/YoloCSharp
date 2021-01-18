using Emgu.CV;
using MultiYoloEmguCv.YoloWrapper.Wrappers;
using System.Collections.Generic;

namespace MultiYoloEmguCv.YoloWrapper
{
    internal class Yolo
    {
        private readonly int _instanceId;
        private readonly int _cudaVersion;
        public Yolo(string cfgFile, string weightFile, int gpuId, int instanceId, int cudaVersion)
        {
            _instanceId = instanceId;
            _cudaVersion = cudaVersion;

            switch (_instanceId)
            {
                default:
                case 0:
                    Wrapper0.Init(cfgFile, weightFile, gpuId);
                    break;
                case 1:
                    Wrapper1.Init(cfgFile, weightFile, gpuId);
                    break;
                case 2:
                    Wrapper2.Init(cfgFile, weightFile, gpuId);
                    break;
                case 3:
                    Wrapper3.Init(cfgFile, weightFile, gpuId);
                    break;
            }
        }
        public List<YoloResult> Detect(Mat mat, float thresh = 0.2f)
        {
            List<YoloResult> results;
            switch (_cudaVersion)
            {
                default:
                case 10:
                    results = Detect10(mat, thresh);
                    break;
                case 11:
                    results = Detect11(mat, thresh);
                    break;
            }
            return results;
        }
        private unsafe List<YoloResult> Detect10(Mat mat, float thresh = 0.2f)
        {
            BoundingBox10* elems;
            int elemsSize;
            switch (_instanceId)
            {
                default:
                case 0:
                    Wrapper0.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out elems, out elemsSize);
                    break;
                case 1:
                    Wrapper1.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out elems, out elemsSize);
                    break;
                case 2:
                    Wrapper2.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out elems, out elemsSize);
                    break;
                case 3:
                    Wrapper3.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out elems, out elemsSize);
                    break;
            }
            return GetResults(elems, elemsSize);
        }
        private unsafe List<YoloResult> Detect11(Mat mat, float thresh = 0.2f)
        {
            BoundingBox11* elems;
            int elemsSize;
            switch (_instanceId)
            {
                default:
                case 0:
                    Wrapper0.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out elems, out elemsSize);
                    break;
                case 1:
                    Wrapper1.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out elems, out elemsSize);
                    break;
                case 2:
                    Wrapper2.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out elems, out elemsSize);
                    break;
                case 3:
                    Wrapper3.Detect(mat.DataPointer, mat.Rows, mat.Cols, thresh, false, out elems, out elemsSize);
                    break;
            }
            return GetResults(elems, elemsSize);
        }
        public void Dispose()
        {
            switch (_instanceId)
            {
                default:
                case 0:
                    Wrapper0.Close();
                    break;
                case 1:
                    Wrapper1.Close();
                    break;
                case 2:
                    Wrapper2.Close();
                    break;
                case 3:
                    Wrapper3.Close();
                    break;
            }
        }
        private unsafe List<YoloResult> GetResults(BoundingBox10* elems, int elemsSize)
        {
            var results = new List<YoloResult>(elemsSize);
            for (var i = 0; i < elemsSize; i++)
            {
                results.Add(new YoloResult(elems[i].x, elems[i].y, elems[i].w, elems[i].h, elems[i].prob, elems[i].obj_id));
            }
            return results;
        }
        private unsafe List<YoloResult> GetResults(BoundingBox11* elems, int elemsSize)
        {
            var results = new List<YoloResult>(elemsSize);
            for (var i = 0; i < elemsSize; i++)
            {
                results.Add(new YoloResult(elems[i].x, elems[i].y, elems[i].w, elems[i].h, elems[i].prob, elems[i].obj_id));
            }
            return results;
        }
    }
}
