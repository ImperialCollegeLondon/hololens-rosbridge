
namespace ros
{
    public static class HeaderExtensions
    {
        public static void Update(this std_msgs.Header header)
        {
            double time = UnityEngine.Time.realtimeSinceStartup;
            header.seq++;
            header.stamp = time;
        }
    }
}
