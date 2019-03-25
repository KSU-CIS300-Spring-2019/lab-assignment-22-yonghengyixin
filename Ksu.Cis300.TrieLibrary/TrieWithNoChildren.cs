using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        bool _check = false;

        /// <summary>
        /// add item when it can
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if(s == "")
            {
                _check = true;
            }
            else
            {
                return new TrieWithOneChildren(s, _check);
            }
            return this;
        }

        /// <summary>
        /// check it can be add or not
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if(s == "")
            {
                return _check;
            }
            else
            {
                return false;
            }
        }
    }
}
