
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

    public interface ILimit
    {
        bool ShouldLimit(GameObject who);
        void Limited(GameObject who);
    }

    public interface IUseItem
    {
        void UseItem(GameObject who);
    }
    public interface IUseSpecial
    {
        void UseSpecial(GameObject who);
    }
    public interface ILookSpecial
    {
        void LookSpecial(GameObject who);
    }
}