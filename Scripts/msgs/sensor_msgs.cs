using System.Collections.Generic;
using System.Linq;
using SimpleJSON;

namespace ros
{
    namespace sensor_msgs
    {
        public class Joy : IRosClassInterface
        {
            public std_msgs.Header header;
            public List<float> axes;
            public List<int> buttons;

            public Joy()
            {
                header = new std_msgs.Header();
                axes = new List<float>();
                buttons = new List<int>();
            }
            public Joy(std_msgs.Header _header, List<float> _axes, List<int> _buttons)
            {
                header = _header;
                axes = _axes;
                buttons = _buttons;
            }

            public void FromJSON(JSONNode msg)
            {
                header.FromJSON(msg["header"]);
                foreach (var t in msg["axes"].Children)
                {
                    axes.Add((float)t.AsDouble);
                }
                foreach (var t in msg["buttons"].Children)
                {
                    axes.Add((int)t.AsDouble);
                }
            }
            public System.String ToJSON()
            {
                System.String ret = "{";
                ret += "\"header\": " + header.ToJSON() + ", ";
                ret += "\"axes\": [";
                ret += System.String.Join(", ", axes.Select(a => a.ToString()).ToArray());
                ret += "], \"buttons\": [";
                ret += System.String.Join(", ", buttons.Select(a => a.ToString()).ToArray());
                ret += "]}";
                return ret;
            }

        }

        public class CompressedImage : IRosClassInterface
        {
            public std_msgs.Header header;
            public System.String format;
            public byte[] data;
            public CompressedImage()
            {
                header = new std_msgs.Header();
                format = "";
                data = new byte[0];
            }
            public CompressedImage(std_msgs.Header _header, System.String _format, byte[] _data)
            {
                header = _header;
                format = _format;
                data = _data;
            }
            public void FromJSON(JSONNode msg)
            {
                System.String encoded;

                header.FromJSON(msg["header"]);
                format = msg["format"].Value;

                encoded = msg["data"];
                data = System.Convert.FromBase64String(encoded);
            }
            public System.String ToJSON()
            {
                System.String ret = "{";
                ret += "\"header\": " + header.ToJSON() + ", ";
                ret += "\"format\": \"" + format + "\", ";
                ret += "\"data\": [";
                ret += System.String.Join(", ", data.Select(a => a.ToString()).ToArray());
                ret += "]}";
                return ret;
            }
        }// CompressedImage

        public class PointField : IRosClassInterface
        {
            public System.String name;
            public System.UInt32 offset;
            public System.Byte datatype;
            public System.UInt32 count;

            public PointField()
            {
                name = "";
                offset = 0;
                datatype = 0;
                count = 0;
            }

            public PointField(System.String _name, System.UInt32 _offset, System.Byte _datatype, System.UInt32 _count)
            {
                name = _name;
                offset = _offset;
                datatype = _datatype;
                count = _count;
            }

            public void FromJSON(JSONNode msg)
            {
                name = msg["name"].Value;
                offset = (System.UInt32)msg["offset"].AsDouble;
                datatype = (System.Byte)msg["datatype"].AsDouble;
                count = (System.UInt32)msg["count"].AsDouble;
            }

            public System.String ToJSON()
            {
                System.String ret = "{";
                ret += "\"name\": \"" + name + "\", ";
                ret += "\"offset\": " + offset.ToString() + ", ";
                ret += "\"datatype\": " + datatype.ToString() + ", ";
                ret += "\"count\": " + count.ToString();
                ret += "}";
                return ret;
            }
        }// PointField

        public class PointCloud2 : IRosClassInterface
        {
            public std_msgs.Header header;
            public System.UInt32 height;
            public System.UInt32 width;

            public List<PointField> fields;

            public System.Boolean is_bigendian;
            public System.UInt32 point_step;
            public System.UInt32 row_step;
            public byte[] data;
            public System.Boolean is_dense;

            public PointCloud2()
            {
                header = new std_msgs.Header();
                height = 0;
                width = 0;

                fields = new List<PointField>();

                is_bigendian = false;
                point_step = 0;
                row_step = 0;
                data = new byte[0];
                is_dense = false;

            }

            public PointCloud2(std_msgs.Header _header, System.UInt32 _height, System.UInt32 _width, List<PointField> _fields, System.Boolean _is_bigendian, System.UInt32 _point_step, System.UInt32 _row_step, byte[] _data, System.Boolean _is_dense)
            {
                header = _header;
                height = _height;
                width = _width;

                fields = _fields;

                is_bigendian = _is_bigendian;
                point_step = _point_step;
                row_step = _row_step;
                data = _data;
                is_dense = _is_dense;
            }

            public void FromJSON(JSONNode msg)
            {
                System.String encoded;
                encoded = msg["data"];

                header.FromJSON(msg["header"]);
                height = (System.UInt32)msg["height"].AsDouble;
                width = (System.UInt32)msg["width"].AsDouble;

                fields = new List<PointField>();
                foreach (var t in msg["fields"].Children)
                {
                    PointField temp = new PointField();
                    temp.FromJSON(t);
                    fields.Add(temp);
                }

                is_bigendian = msg["is_bigendian"].AsBool;
                point_step = (System.UInt32)msg["point_step"].AsDouble;
                row_step = (System.UInt32)msg["row_step"].AsDouble;
                data = System.Convert.FromBase64String(encoded);
                is_dense = msg["is_dense"].AsBool;

            }

            public System.String ToJSON()
            {
                System.String ret = "{";
                ret += "\"header\": " + header.ToJSON() + ", ";
                ret += "\"height\": " + height.ToString() + ", ";
                ret += "\"width\": " + width.ToString() + ", ";

                ret += "\"fields\": [";
                ret += System.String.Join(", ", fields.Select(a => a.ToJSON()).ToArray());
                ret += "]" + ", ";

                ret += "\"is_bigendian\": " + is_bigendian.ToString() + ", ";
                ret += "\"point_step\": " + point_step.ToString() + ", ";
                ret += "\"row_step\": " + row_step.ToString() + ", ";

                ret += "\"data\": [";
                ret += System.String.Join(", ", data.Select(a => a.ToString()).ToArray());
                ret += "]" + ", ";

                ret += "\"is_dense\": " + is_dense.ToString();
                ret += "}";
                return ret;
            }
        }// PointCloud2
    } // sensor_msgs
} // ros