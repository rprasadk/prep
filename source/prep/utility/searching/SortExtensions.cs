using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.utility.searching
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public static class SortExtensions
    {

        public static SortExtension<Target> sortby<Target, PropertyType>
            (this IEnumerable<Target> items, PropertyAccessor<Target, PropertyType> accessor, 
            SortDirection sort_direction = SortDirection.Ascending)
        {
            return new SortExtension<Target>(items).by(accessor, sort_direction); //TBD redesign
        }

        //public static SortExtension<Target> by(
        //    this SortExtension<Target> extension_point,)
    }

   

    public class SortExtension<Target>
    {
        private class SortComparer<Target> : IComparable<Target>
        {
            public int CompareTo(Target other)
            {
                throw new NotImplementedException();
            }
        }

        private readonly IEnumerable<Target> _items;
        private SortComparer<Target> _sortComparer;

        public SortExtension(IEnumerable<Target> items)
        {
            _items = items;
            _sortComparer = new SortComparer<Target>();
        } 
       
        public SortExtension<Target> by<PropertyType>(
            PropertyAccessor<Target, PropertyType> accessor, 
            SortDirection sortDirection)
        {
            _sortComparer.AddCondition(accessor, sortDirection);
            return this;
        }

        public SortExtension<Target> thenby<PropertyType>
            (PropertyAccessor<Target, PropertyType> accessor, 
            SortDirection sort_direction = SortDirection.Ascending)
        {            
            return by(accessor, sort_direction);
        }

        public IEnumerable<Target> go()
        {
            return Array.Sort(_items, _sortComparer);
        }
        
    }    
}
