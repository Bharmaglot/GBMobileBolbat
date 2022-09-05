using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesRepository : IAbilityRepository
{
    public readonly List<AbilityItemConfig> _abilities;
    
    public AbilitiesRepository(List<AbilityItemConfig> abilities)
    {
        _abilities = abilities;
    }

   public IReadOnlyDictionary<int IAbility> AbilitiesMap { get; }
}
