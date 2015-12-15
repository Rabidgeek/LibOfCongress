using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOfCongress
{
    public struct LoCnum
    {
        private int num;

        public LoCnum(int num)
        {
            this.num = num;
        }

        public override string ToString()
        {
            string num = this.num.ToString().PadLeft(7, '0');
            return String.Format("{0}-{1}", num.Substring(0, 2), num.Substring(2, 5));
        }

        public static explicit operator int(LoCnum loCnum)
        {
            return loCnum.Num;
        }

        public int Num
        {
            get { return num; }
            set
            {
                if (value > 9999999 || value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                num = value;
            }
        }
    }
}
