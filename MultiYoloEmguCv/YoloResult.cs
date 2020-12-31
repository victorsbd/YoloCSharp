namespace MultiYoloEmguCv
{
    /// <summary>
    /// Represents the detection information of an object by Yolo
    /// </summary>
    public class YoloResult
    {
        /// <summary>
        /// X coordinate of the top-left corner of bounded box
        /// </summary>
        public uint X { get; }

        /// <summary>
        /// Y coordinate of the top-left corner of bounded box
        /// </summary>
        public uint Y { get; }

        /// <summary>
        /// Width of bounded box
        /// </summary>
        public uint Width { get; }

        /// <summary>
        /// Height of bounded box
        /// </summary>
        public uint Height { get; }

        /// <summary>
        /// Probability that the object was found correctly
        /// </summary>
        public float Confidence { get; }

        /// <summary>
        /// Class of object - from range [0, classes-1]
        /// </summary>
        public uint ObjId { get; }

        public YoloResult(uint x, uint y, uint width, uint height, float confidence, uint objId)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Confidence = confidence;
            ObjId = objId;
        }
    }
}
