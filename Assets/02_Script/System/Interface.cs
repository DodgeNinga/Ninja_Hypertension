using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interface
{

    public interface IEventObject
    {

        public void AddEvent();
        public void RemoveEvent();

    }

    public interface IHpObject
    {

        public float HP { get; set;}
        public void TakeDamage(float damage);
        public void HealingHP(float healPoint);

    }

}