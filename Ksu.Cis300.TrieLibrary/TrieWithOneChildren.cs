using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChildren : ITrie
    {

        private bool _check;
        private ITrie _child;
        private char _label;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="child"></param>
        /// <param name="check"></param>
        public TrieWithOneChildren(string child, bool check)
        {
            if(child == "" || child[0] < 'a' || child[0] > 'z')
            {
                throw new ArgumentException();
            }
            _check = check;
            _label = child[0];
            _child = new TrieWithNoChildren().Add(child.Substring(1));
        }

        /// <summary>
        /// add item to ITrie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _check = true;
            }
            else if (s[0].Equals(_label))
            {
                _child = _child.Add(s.Substring(1));
            }
            else
            {
                return new TrieWithManyChildren(s,_check,_label,_child);
            }
            return this;
        }

        /// <summary>
        /// check can be add or not
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if(s == "")
            {
                return _check;
            }
            else if (s[0].Equals(_label))
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
