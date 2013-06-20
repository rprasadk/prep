using System.Collections.Generic;

namespace prep.utility.searching
{
  public static class IEnumerableExtensions
  {
    public static CollectionFilteringExtensionPoint<Target, AttributeType> where<Target, AttributeType>
      (this IEnumerable<Target> items, PropertyAccessor<Target, AttributeType> accessor)
    {
        return new CollectionFilteringExtensionPoint<Target, AttributeType>(items, accessor);
    }
  }

  //public static class CollectionFilteringExtensions
  //{
  //  public static IEnumerable<Target> equal_to<Target, AttributeType>(
  //    this CollectionFilteringExtensionPoint<Target, AttributeType> extension_point,
  //    AttributeType value)
  //  {
  //    var criteria = Match<Target>.attribute(extension_point.accessor).equal_to(value);
  //    return extension_point.filter_using_criteria(criteria);
  //  }
  //}
}