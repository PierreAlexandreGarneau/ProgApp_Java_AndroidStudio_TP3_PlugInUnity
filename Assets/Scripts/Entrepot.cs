using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Construction : MonoBehaviour
    {

        public abstract string Name();

        public abstract int EnergyCost();

        public abstract int Ressource1Cost();

        public abstract int Ressource2Cost();

        public abstract string Type();

        public virtual string Information()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name:" + Name());
            sb.AppendLine("Type : " + Type());
            sb.AppendLine("Cost:");
            sb.AppendLine("Energy : " + EnergyCost());
            sb.AppendLine("Ressource 1 : " + Ressource1Cost());
            sb.AppendLine("Ressource 2 : " + Ressource2Cost());
            return sb.ToString();
        }
    }

    public abstract class Entrepot : Construction
    {
        public abstract int Capacity();
    }

    public class Entrepot1 : Entrepot
    {
        public override string Name()
        {
            return "Entrepot 1";
        }

        public override int EnergyCost()
        {
            return 20;
        }

        public override int Ressource1Cost()
        {
            return 0;
        }

        public override int Ressource2Cost()
        {
            return 0;
        }

        public override int Capacity()
        {
            return 1000;
        }

        public override string Type()
        {
            return "Ressource 1";
        }
    }

    public class Entrepot2 : Entrepot
    {
        public override int EnergyCost()
        {
            return 50;
        }

        public override string Name()
        {
            return "Entrepot 2";
        }

        public override int Ressource1Cost()
        {
            return 45;
        }

        public override int Ressource2Cost()
        {
            return 0;
        }

        public override int Capacity()
        {
            return 1000;
        }

        public override string Type()
        {
            return "Ressource 2";
        }
    }

    public abstract class Usine : Construction
    {
        public float IncreasePerSec;
        public int Current;
        public abstract int Max();
        public abstract int StartECost();
        public bool started = false;
        public float Delta;
        public virtual int StartR1Cost()
        {
            return 0;
        }
        public virtual int StartR2Cost()
        {
            return 0;
        }

        public Usine()
        {
            Current = 0;
            Delta = 0;
        }

        void Update()
        {
            Delta += Time.deltaTime;
            if (started && Delta >= IncreasePerSec && Current < Max())
            {
                Current++;
                Delta = 0;
            }
        }

        public void StartUsine()
        {
            started = true;
        }

        public int Recolter()
        {
            started = false;
            var r = Current;
            Current = 0;
            return r;
        }

        public override string Information()
        {
            StringBuilder sb = new StringBuilder(base.Information());
            sb.AppendLine();
            sb.AppendLine("Current statut:");
            sb.AppendLine(Current + "/" + Max());
            return sb.ToString();
        }

    }

    public class Usine1 : Usine
    {
        public override int EnergyCost()
        {
            return 50;
        }

        public override int Max()
        {
            return 50;
        }

        public override string Name()
        {
            return "Usine 2";
        }

        public override int Ressource1Cost()
        {
            return 45;
        }

        public override int Ressource2Cost()
        {
            return 0;
        }

        public override int StartECost()
        {
            return 10;
        }

        public override string Type()
        {
            return "Ressource 1";
        }
    }

    public class Usine2 : Usine
    {
        public override int EnergyCost()
        {
            return 50;
        }

        public override int Max()
        {
            return 50;
        }

        public override string Name()
        {
            return "Usine 2";
        }

        public override int Ressource1Cost()
        {
            return 45;
        }

        public override int Ressource2Cost()
        {
            return 0;
        }

        public override int StartECost()
        {
            return 20;
        }

        public override int StartR1Cost()
        {
            return 40;
        }

        public override string Type()
        {
            return "Ressource 2";
        }
    }
}
