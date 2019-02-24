using AutoMapper;

namespace Sample.Utilities
{
    public static class AutoMapperHelper
    {
        public static TDest MapTo<TDest>(this object src)
        {
            return (TDest)Mapper.Map(src, src.GetType(), typeof(TDest));
        }
    }
}
