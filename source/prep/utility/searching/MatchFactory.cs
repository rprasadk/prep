﻿using System.Collections.Generic;

namespace prep.utility.searching
{
  public class MatchFactory<Target, PropertyType> : IBuildMatchers<Target, PropertyType>
  {
    PropertyAccessor<Target, PropertyType> accessor;

    public MatchFactory(PropertyAccessor<Target, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<Target> equal_to(PropertyType value)
    {
      return equal_to_any(value);
    }

    public IMatchA<Target> equal_to_any(params PropertyType[] values)
    {
      return AnonymousMatch<Target>.Create(x =>
      {
        var value = accessor(x);
        var possible_values = new List<PropertyType>(values);
        return possible_values.Contains(value);
      });      
    }

    public IMatchA<Target> not_equal_to(PropertyType value)
    {
      return equal_to(value).not();
    }
  }
}