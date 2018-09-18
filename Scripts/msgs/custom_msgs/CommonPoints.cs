using SimpleJSON;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ros
{
    namespace holo_ros_utils
    {
        public class CommonPoints : IRosClassInterface
        {
            public long secs;
            public long nsecs;
            public System.String frame_id;

            public List<geometry_msgs.Point> points;

            public CommonPoints()
            {
                secs = new long();
                nsecs = new long();
                frame_id = " ";
                points = new List<geometry_msgs.Point>();
            }

            public CommonPoints(long _secs, long _nsecs, System.String _frame_id, List<geometry_msgs.Point> _points)
            {
                secs = _secs;
                nsecs = _nsecs;
                frame_id = _frame_id;
                points = _points;
            }

            public void FromJSON(JSONNode msg)
            {
                secs = msg["stamp"]["secs"];
                nsecs = msg["stamp"]["nsecs"];
                frame_id = msg["frame_id"].Value;

                var msg_points = msg["points"].Children;
                foreach (var p in msg_points)
                {
                    geometry_msgs.Point temp = new geometry_msgs.Point();
                    temp.FromJSON(p);
                    points.Add(temp);
                }
            }

            public System.String ToJSON()
            {
                System.String ret = "{";

                ret += "\"stamp\": "
                        + "{" + "\"secs\": " + secs.ToString() + ", "
                        + "\"nsecs\": " + nsecs.ToString() + "}" + ", ";
                ret += "\"frame_id\": \"" + frame_id + "\", ";

                ret += "\"points\": [";
                ret += System.String.Join(", ", points.Select(a => a.ToJSON()).ToArray());
                ret += "]}";

                return ret;
            }
        }
    }
}
