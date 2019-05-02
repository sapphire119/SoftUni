using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Abstracts;


namespace DungeonsAndCodeWizards.Abstracts.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
