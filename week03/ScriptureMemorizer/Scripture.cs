using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        public string GetDisplayText()
        {
            return $"{_reference.GetDisplayText()}\n" + string.Join(" ", _words.Select(w => w.GetDisplayText()));
        }

        public void HideRandomWords(int count)
        {
            var notHidden = _words.Where(w => !w.IsHidden()).ToList();
            if (notHidden.Count == 0) return;
            var rand = new Random();
            for (int i = 0; i < count && notHidden.Count > 0; i++)
            {
                int idx = rand.Next(notHidden.Count);
                notHidden[idx].Hide();
                notHidden.RemoveAt(idx);
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}
