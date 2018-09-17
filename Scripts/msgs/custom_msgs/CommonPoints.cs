using SimpleJSON;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ros
{
    namespace ros_world
    {
        public class CommonPoints : IRosClassInterface
        {
            public long secs;
            public long nsecs;
            public System.String frame_id;

            public geometry_msgs.Point[] points;

            public CommonPoints()
            {
                secs = new long();
                nsecs = new long();
                frame_id = " ";
                points = new geometry_msgs.Point[0];
            }

            public CommonPoints(long _secs, long _nsecs, System.String _frame_id, geometry_msgs.Point[] _parr)
            {
                secs = _secs;
                nsecs = _nsecs;
                frame_id = _frame_id;
                points = new geometry_msgs.Point[_parr.Length];

                foreach (var p in _parr)
                {
                    points.Add(p);
                }
            }

            public void FromJSON(JSONNode msg)
            {
                secs = msg["stamp"]["secs"];
                nsecs = msg["stamp"]["nsecs"];
                frame_id = msg["frame_id"].Value;

                foreach (var p in msg["points"].Children)
                {
                    geometry_msgs.Point temp = new geometry_msgs.Point();
                    temp.FromJSON(p);
                    points.Add(p);
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
