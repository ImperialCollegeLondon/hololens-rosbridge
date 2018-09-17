using SimpleJSON;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ros
{
    //namespace custom_msgs
    namespace explainable_reality
    {

        public class CommonPoints : IRosClassInterface
        {
            public long secs;
            public long nsecs;
            public System.String frame_id;

            public geometry_msgs.Point p1;
            public geometry_msgs.Point p2;
            public geometry_msgs.Point p3;


            public CommonPoints()
            {
                secs = new long();
                nsecs = new long();
                frame_id = " ";

                p1 = new geometry_msgs.Point();
                p2 = new geometry_msgs.Point();
                p3 = new geometry_msgs.Point();

            }

            public CommonPoints(long _secs, long _nsecs, System.String _frame_id, geometry_msgs.Point _p1, geometry_msgs.Point _p2, geometry_msgs.Point _p3)
            {
                secs = _secs;
                nsecs = _nsecs;
                frame_id = _frame_id;
                p1 = _p1;
                p2 = _p2;
                p3 = _p3;
            }

            public void FromJSON(JSONNode msg)
            {
                secs = msg["stamp"]["secs"];
                nsecs = msg["stamp"]["nsecs"];
                frame_id = msg["frame_id"].Value;

                p1.FromJSON(msg["p1"]);
                p2.FromJSON(msg["p2"]);
                p3.FromJSON(msg["p3"]);
            }

            public System.String ToJSON()
            {
                System.String ret = "{";

                ret += "\"stamp\": "
                        + "{" + "\"secs\": " + secs.ToString() + ", "
                        + "\"nsecs\": " + nsecs.ToString() + "}" + ", ";
                ret += "\"frame_id\": \"" + frame_id + "\", ";
                ret += "\"p1\": " + "{"
                       + "\"y\": " + p1.y.ToString("F3") + ", "
                       + "\"x\": " + p1.x.ToString("F3") + ", "
                       + "\"z\": " + p1.z.ToString("F3") + "}" + ", ";
                ret += "\"p2\": " + "{"
                       + "\"y\": " + p2.y.ToString("F3") + ", "
                       + "\"x\": " + p2.x.ToString("F3") + ", "
                       + "\"z\": " + p2.z.ToString("F3") + "}" + ", ";
                ret += "\"p3\": " + "{"
                       + "\"y\": " + p3.y.ToString("F3") + ", "
                       + "\"x\": " + p3.x.ToString("F3") + ", "
                       + "\"z\": " + p3.z.ToString("F3") + "}";
                ret += "}";
                return ret;
            }
        }
    }
}
