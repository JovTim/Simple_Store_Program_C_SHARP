using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount_Store
{
    internal class discount
    {
        public int loyaltyDiscount(int totalPrice)
        {
            float dis = totalPrice * 0.5F;
            return totalPrice - (int)Math.Round(dis);

        }

        public int seniorDiscount(int totalPrice)
        {
            float dis = totalPrice * 0.3F;
            return totalPrice - (int)Math.Round(dis);
        }

        public int studentDiscount(int totalPrice)
        {
            float dis = totalPrice * 0.15F;
            return totalPrice - (int)Math.Round(dis);
        }
    }
}
