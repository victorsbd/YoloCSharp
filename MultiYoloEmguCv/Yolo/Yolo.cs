using System.Collections.Generic;

namespace MultiYoloEmguCv.Yolo
{
    internal abstract class Yolo
    {
        protected unsafe List<YoloResult> GetResults(BoundingBox* elems, int elemsSize)
        {
            var results = new List<YoloResult>(elemsSize);
            for (var i = 0; i < elemsSize; i++)
            {
                results.Add(new YoloResult(elems[i].X, elems[i].Y, elems[i].W, elems[i].H, elems[i].Prob, elems[i].ObjId));
            }
            return results;
        }
    }
}
