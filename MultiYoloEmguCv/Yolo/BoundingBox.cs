namespace MultiYoloEmguCv.Yolo
{
    // same as c++ struct bbox_t from yolo_v2_class
    // need to disable check for Field XYZ is never assigned to, and will always have its default value XX
    // because the struct is initialized in the c++ code
    #pragma warning disable 0649
    internal struct BoundingBox
    {
        internal uint X, Y, W, H;
        internal float Prob;
        internal uint ObjId;
        internal uint TrackId;
        internal uint FramesCounter;
    }
    #pragma warning restore 0649
}
