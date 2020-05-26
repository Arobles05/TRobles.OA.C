using System;
using System.Collections.Generic;
using System.Text;

namespace TRobles.OA.C.Common.Interfaces
{
    public interface IPagedList<T>
    {
        int TotalItemCount { get; set; }
        int Count { get; set; }
        int PageCount { get; set; }
        int CurrentPage { get; set; }
        T[] Data { get; set; }

        IPagedList<TResult> TransformData<TResult>(Func<IEnumerable<T>, IEnumerable<TResult>> transform);
    }
}
