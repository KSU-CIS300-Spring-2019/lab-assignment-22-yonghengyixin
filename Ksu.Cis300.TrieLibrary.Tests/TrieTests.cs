/* TrieTests.cs
 * Author: Rod Howell
 */

namespace Ksu.Cis300.TrieLibrary.Tests
{
    using NUnit.Framework;
    using System;

    /// <summary>
    /// Unit tests for the Trie class.
    /// </summary>
    [TestFixture]
    public class TrieTests
    {
        /// <summary>
        /// Tests looking up an empty string in an empty trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyContainsEmptyString()
        {
            Trie t = new Trie();
            Assert.That(t.Contains(""), Is.False);
        }

        /// <summary>
        /// Tests looking up a nonempty string in an empty trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyContainsNonemptyString()
        {
            Trie t = new Trie();
            Assert.That(t.Contains("word"), Is.False);
        }

        /// <summary>
        /// Tests looking up a string with an invalid character.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyContainsInvalidString()
        {
            Trie t = new Trie();
            Assert.That(t.Contains("`"), Is.False);
        }

        /// <summary>
        /// Tests lookup a longer string with an invalid character.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyContainsLongerInvalidString()
        {
            Trie t = new Trie();
            Assert.That(t.Contains("ab{d"), Is.False);
        }

        /// <summary>
        /// Adds the empty string to an empty trie and looks it up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddEmptyLookItUp()
        {
            Trie t = new Trie();
            t.Add("");
            Assert.That(t.Contains(""), Is.True);
        }

        /// <summary>
        /// Tests adding a string with an invalid character.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddInvalid()
        {
            Exception e = null;
            Trie t = new Trie();
            try
            {
                t.Add("`");
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
        }

        /// <summary>
        /// Tests adding another invalid string.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddInvalid2()
        {
            Exception e = null;
            Trie t = new Trie();
            try
            {
                t.Add("{");
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.That(e, Is.Not.Null.And.TypeOf(typeof(ArgumentException)));
        }

        /// <summary>
        /// Adds a 1-letter word and looks it up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCAddShortWordLookItUp()
        {
            Trie t = new Trie();
            t.Add("i");
            Assert.That(t.Contains("i"), Is.True);
        }

        /// <summary>
        /// Adds a longer word and looks it up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDAddLongWordLookItUp()
        {
            Trie t = new Trie();
            t.Add("word");
            Assert.That(t.Contains("word"), Is.True);
        }

        /// <summary>
        /// Adds a word and looks up a prefix that should not be in the trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDAddWordLookUpPrefix()
        {
            Trie t = new Trie();
            t.Add("word");
            Assert.That(t.Contains("wo"), Is.False);
        }

        /// <summary>
        /// Strings to add to the trie for the following tests.
        /// </summary>
        private string[] _words = new string[]
        {
            "cab",
            "dog",
            "cart",
            "car",
            "cable"
        };

        /// <summary>
        /// Builds a trie containing the strings in _words.
        /// </summary>
        /// <returns>The resulting trie.</returns>
        private Trie LoadTrie()
        {
            Trie t = new Trie();
            foreach (string s in _words)
            {
                t.Add(s);
            }
            return t;
        }

        /// <summary>
        /// Loads a trie with five words and looks one up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestELookupInLarger()
        {
            Trie t = LoadTrie();
            Assert.That(t.Contains("dog"), Is.True);
        }

        /// <summary>
        /// Looks up a prefix that was added after the longer word.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestELookupPrefixAddedAfter()
        {
            Trie t = LoadTrie();
            Assert.That(t.Contains("car"), Is.True);
        }

        /// <summary>
        /// Looks up a prefix that was added before the longer word.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestELookupPrefixAddedBefore()
        {
            Trie t = LoadTrie();
            Assert.That(t.Contains("cab"), Is.True);
        }

        /// <summary>
        /// Looks up a word that has a prefix added earlier.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestELookupWordWithPrefixAddedBefore()
        {
            Trie t = LoadTrie();
            Assert.That(t.Contains("cable"), Is.True);
        }

        /// <summary>
        /// Looks up a word that has a prefix added later.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestELookupWordWithPrefixAddedAfter()
        {
            Trie t = LoadTrie();
            Assert.That(t.Contains("cart"));
        }
    }
}