using System.Collections.Generic;
namespace MultiYoloEmguCv.Yolo
{
    internal abstract class YoloCppDll
    {
        protected List<YoloResult> GetResults(int count, BboxContainer container)
        {
            var results = new List<YoloResult>(count);
            for (var i = 0; i < count; i++)
            {
                var elem = container.candidates[i];
                results[i] = new YoloResult(elem.x, elem.y, elem.w, elem.h, elem.prob, elem.obj_id);
            }
            return results;
        }
    }
}
