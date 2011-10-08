using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VanillaMain2
{
    class VanillaOption
    {
        public VanillaOption(PayOff payoff_, double expiry_)
        {
            this.payoff = payoff_.Clone();
            this.Expiry = expiry_;
        }
        public VanillaOption(VanillaOption original)
        {
            this.payoff = original.payoff.Clone();
            this.Expiry = original.Expiry;
        }
        public VanillaOption DeepCopy()
        {
            return new VanillaOption(this);
        }
        public double PayOff(double spot_)
        {
            return payoff.Do(spot_);
        }

        public double Expiry{get; private set;}
        private PayOff payoff;
    }
}
