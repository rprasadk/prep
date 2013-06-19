using System;

namespace prep.utility.searching
{
  public class AnonymousMatch<Item> : IMatchA<Item>
  {
    Criteria<Item> condition;

    public AnonymousMatch(Criteria<Item> condition)
    {
      this.condition = condition;
    }

    public bool matches(Item item)
    {
      return condition(item);
    }

    public static IMatchA<Item> Create(Criteria<Item> condition)
    {
        return new AnonymousMatch<Item>(condition);
    }
  }
}