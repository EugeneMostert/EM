using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    public interface IDataMapper
    {
        Dictionary<Type, string> MapDataType(IDictionary<MapperDataType, string> dataMapping);
    }

    class DataMapper : IDataMapper
    {
        public DataMapper()
        {
        }

        public Dictionary<Type, string> MapDataType(IDictionary<MapperDataType, string> dataMapping)
        {
            var mappedTypes = new Dictionary<Type, string>();
            foreach(var type in dataMapping)
            {
                var t = GetDataType(type.Key);
                mappedTypes.Add(t, type.Value);
            }

            return mappedTypes;
        }

        private Type GetDataType(MapperDataType mapperDataType)
        {
            switch (mapperDataType)
            {
                case MapperDataType.Int:
                    return typeof(int);
                case MapperDataType.String:
                    return typeof(string);
                case MapperDataType.Bool:
                    return typeof(bool);
                case MapperDataType.DateTime:
                    return typeof(DateTime);
                case MapperDataType.Float:
                    return typeof(float);
                case MapperDataType.Decimal:
                    return typeof(decimal);
                case MapperDataType.Guid:
                    return typeof(Guid);
                default:
                    return null;
            }
        }


        //public string DataProp { get; set; }

        //public string Int { get; set; }
        //public string String { get; set; }
        //public string Bool { get; set; }
        //public string DateTime { get; set; }
        //public string Float { get; set; }
        //public string Decimal { get; set; }
        //public string Guid { get; set; }

        //private Dictionary<Type, string> dataMapper
        //{
        //    get
        //    {
        //        // Add the rest of your CLR Types to SQL Types mapping here
        //        Dictionary<Type, string> dataMapper = new Dictionary<Type, string>();
        //        dataMapper.Add(typeof(int), Int);
        //        dataMapper.Add(typeof(string), String);
        //        dataMapper.Add(typeof(bool), Bool);
        //        dataMapper.Add(typeof(DateTime), DateTime);
        //        dataMapper.Add(typeof(float), Float);
        //        dataMapper.Add(typeof(decimal), Decimal);
        //        dataMapper.Add(typeof(Guid), !string.IsNullOrEmpty(Guid) ? Guid : "UNIQUEIDENTIFIER");

        //        return dataMapper;
        //    }
        //}
    }

    public interface IDataTypeConfig
    {
        string Int { get; set; }
        string String { get; set; }
        string Bool { get; set; }
        string DateTime { get; set; }
        string Float { get; set; }
        string Decimal { get; set; }
        string Guid { get; set; }
    }

    public interface IDataType
    {
        string Int { get; set; }
        string String { get; set; }
        string Bool { get; set; }
        string DateTime { get; set; }
        string Float { get; set; }
        string Decimal { get; set; }
        string Guid { get; set; }
    }

    public enum MapperDataType
    {
        Int,
        String,
        Bool,
        DateTime,
        Float,
        Decimal,
        Guid,
    }

    public class DataType : IDataType
    {
        public string Int { get; set; }
        public string String { get; set; }
        public string Bool { get; set; }
        public string DateTime { get; set; }
        public string Float { get; set; }
        public string Decimal { get; set; }
        public string Guid { get; set; }
    }
}
