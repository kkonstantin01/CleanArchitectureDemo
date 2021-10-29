using System.Collections.Generic;

namespace Countries.Application.Converters
{
    public interface ITypeConverter<in TSource, out TDestination>
    {
        TDestination Map(TSource source);

        IEnumerable<TDestination> Map(IEnumerable<TSource> sources);
    }
}
