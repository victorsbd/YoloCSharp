namespace MultiYoloEmguCv.YoloWrapper
{
    // same as c++ struct bbox_t from yolo_v2_class
    // need to disable check for Field XYZ is never assigned to, and will always have its default value XX
    // because the struct is initialized in the c++ code
    #pragma warning disable 0649
    internal struct BoundingBox10
    {
        internal uint x, y, w, h;
        internal float prob;
        internal uint obj_id;
        internal uint track_id;
        internal uint frames_counter;
    }
    #pragma warning restore 0649
}
