
using UnityEngine;

namespace Assets.Script.Interaction
{
    public interface IUse
    {
        void Use(GameObject who);
    }

    public interface ILook
    {
        void Look(GameObject who);
    }

    public interface ITalk
    {
        void Talk(GameObject who);
    }

    public interface ISpecial
    {
        void Special(GameObject who);
    }

    public interface IUseItem
    {
        void UseItem(GameObject who);
    }
}