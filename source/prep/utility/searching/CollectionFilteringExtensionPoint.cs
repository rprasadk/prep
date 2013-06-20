using System.Collections.Generic;

namespace prep.utility.searching
{
    public interface ICreateCriteriaResults<Target>
    {
        IEnumerable<Target> generate_results(IMatchA<Target> criteria);
    }

    public class CollectionFilteringExtensionPoint<Target, AttributeType> : ICreateCriteriaResults<Target>
    {
        public readonly IEnumerable<Target> items;
        public readonly PropertyAccessor<Target, AttributeType> accessor;
        public MatchCreationExtensionPoint<Target, AttributeType> _internalMatchCreationXtnPoint;

        public CollectionFilteringExtensionPoint(IEnumerable<Target> items, 
                PropertyAccessor<Target, AttributeType> accessor)
        {
            this.items = items;
            this.accessor = accessor;
        }

        //public IEnumerable<Target> filter_using_criteria(IMatchA<Target> criteria)
        //{
        //    return items.all_items_matching(criteria);
        //}

        public IEnumerable<Target> generate_results(IMatchA<Target> criteria)
        {
            return items.all_items_matching(criteria);
        }
    }
}